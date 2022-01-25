using Microsoft.AspNetCore.Mvc;
using MusicS.DataAccess;
using MusicS.DataAccess.Repository.IRepository;
using MusicS.Models;

namespace MusicShop.Controllers
{
    [Area("Admin")]
    public class GenreController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Genre> objGenreList = _unitOfWork.Genre.GetAll();

            return View(objGenreList);
        }

        //ADD GENRE//

        //Get
        public IActionResult Add()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Genre obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Genre.Add(obj);
                _unitOfWork.Save();
                TempData["success"]="Genre Created";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //CONFIGURE GENRE//

        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var genreFromDb = _unitOfWork.Genre.GetFirstOrDefault(u=>u.Id==id);
            if(genreFromDb== null)
            {
                return BadRequest();
            }
            return View(genreFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Genre.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Genre Edited";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //DELETE GENRE//

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var genreFromDb = _unitOfWork.Genre.GetFirstOrDefault(u => u.Id == id);
            if (genreFromDb == null)
            {
                return BadRequest();
            }
            return View(genreFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Genre.GetFirstOrDefault(u => u.Id == id);
            if (obj == null){
                return BadRequest();
            }
            _unitOfWork.Genre.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Genre Deleted";
            return RedirectToAction("Index");        
            
        }
    }
}

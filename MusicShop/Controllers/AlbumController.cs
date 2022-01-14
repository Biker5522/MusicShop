using Microsoft.AspNetCore.Mvc;
using MusicS.DataAccess;
using MusicS.DataAccess.Repository.IRepository;
using MusicS.Models;

namespace MusicShop.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AlbumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Album> objAlbumList = _unitOfWork.Album.GetAll();

            return View(objAlbumList);
        }

        //ADD ALBUM//

        //Get
        public IActionResult Add()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Album obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Album.Add(obj);
                _unitOfWork.Save();
                TempData["success"]="Album Created";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //CONFIGURE ALBUM//

        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var albumFromDb = _unitOfWork.Album.GetFirstOrDefault(u=>u.Id==id);
            if(albumFromDb== null)
            {
                return BadRequest();
            }
            return View(albumFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Album obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Album.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Album Edited";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //DELETE ALBUM//

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var albumFromDb = _unitOfWork.Album.GetFirstOrDefault(u => u.Id == id);
            if (albumFromDb == null)
            {
                return BadRequest();
            }
            return View(albumFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Album.GetFirstOrDefault(u => u.Id == id);
            if (obj == null){
                return BadRequest();
            }
            _unitOfWork.Album.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Album Deleted";
            return RedirectToAction("Index");        
            
        }
    }
}

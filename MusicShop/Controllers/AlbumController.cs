using Microsoft.AspNetCore.Mvc;
using MusicShop.Models;

namespace MusicShop.Controllers
{
    public class AlbumController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AlbumController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Album> objAlbumList = _db.Albums;

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
                _db.Albums.Add(obj);
                _db.SaveChanges();
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
            var albumFromDb = _db.Albums.Find(id);
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
                _db.Albums.Update(obj);
                _db.SaveChanges();
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
            var albumFromDb = _db.Albums.Find(id);
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
            var obj = _db.Albums.Find(id);
            if(obj == null){
                return BadRequest();
            }
                _db.Albums.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Album Deleted";
            return RedirectToAction("Index");
            
            return RedirectToAction("Index");
        }
    }
}

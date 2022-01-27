using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicS.DataAccess;
using MusicS.DataAccess.Repository;
using MusicS.DataAccess.Repository.IRepository;
using MusicS.Models;
using MusicS.Models.ViewModels;
using MusicS.Utility;
using System.Linq;

namespace MusicShop.Controllers
{
    [Area("Admin")]
    [Authorize(Roles=SD.Role_Admin)]
    public class AlbumController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AlbumController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnviroment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnviroment;
        }
        public IActionResult Index()
        {
            return View();
        }


        //Get
        public IActionResult Upsert(int? id)
        {
            AlbumVM albumVM = new()
            {

                Album = new(),
                GenreList = _unitOfWork.Genre.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                //create album

                return View(albumVM);
            }
            else
            {
                //edit album
                albumVM.Album = _unitOfWork.Album.GetFirstOrDefault(u => u.Id == id);
                return View(albumVM);

            }
            return View(albumVM);

        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(AlbumVM obj, IFormFile file)
        {
            

                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\albums");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Album.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Album.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    obj.Album.ImageUrl = @"\images\albums\" + fileName + extension;


                    if (obj.Album.Id == 0)
                    {
                        _unitOfWork.Album.Add(obj.Album);
                    }
                    else
                    {
                        _unitOfWork.Album.Update(obj.Album);
                    }


                }


                _unitOfWork.Save();
                TempData["success"] = "Album Added";
                return RedirectToAction("Index");

          
        }
        //POST DELETE
        

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {

            var albumList = _unitOfWork.Album.GetAll(includeProperties:"Genre");
            return Json(new { data = albumList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Album.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Album.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted" });
            
        }
        #endregion
    }


    //DELETE GENRE//

    ////Get
    //public IActionResult Delete(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }
    //    var albumFromDb = _unitOfWork.Album.GetFirstOrDefault(u => u.Id == id);
    //    if (albumFromDb == null)
    //    {
    //        return BadRequest();
    //    }
    //    return View(albumFromDb);
    //}
    ////Post
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public IActionResult DeletePOST(int? id)
    //{
    //    var obj = _unitOfWork.Album.GetFirstOrDefault(u => u.Id == id);
    //    if (obj == null){
    //        return BadRequest();
    //    }
    //    _unitOfWork.Album.Remove(obj);
    //    _unitOfWork.Save();
    //    TempData["success"] = "Album Deleted";
    //    return RedirectToAction("Index");        

    //}

}




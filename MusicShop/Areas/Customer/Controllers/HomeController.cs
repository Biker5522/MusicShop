using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicS.DataAccess.Repository.IRepository;
using MusicS.Models;
using MusicS.Models.ViewModels;
using System.Diagnostics;
using System.Security.Claims;

namespace MusicShop.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Album> albumList = _unitOfWork.Album.GetAll(includeProperties:"Genre");
            return View(albumList);
        }
        public IActionResult Details(int albumId)
        {
            ShoppingCart cartObj = new()
            {
                Count = 1,
                AlbumId = albumId,
                Album = _unitOfWork.Album.GetFirstOrDefault(u => u.Id == albumId, includeProperties: "Genre")
            };
            return View(cartObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCart.ApplicationUserId = claim.Value;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
             u => u.ApplicationUserId == claim.Value && u.AlbumId == shoppingCart.AlbumId);


            if (cartFromDb == null)
            {

                _unitOfWork.ShoppingCart.Add(shoppingCart);
              

            }
            else
            {
                _unitOfWork.ShoppingCart.IncrementCount(cartFromDb, shoppingCart.Count);
                
            }
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));


        }







        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
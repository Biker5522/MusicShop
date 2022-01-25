using Microsoft.AspNetCore.Mvc;
using MusicS.DataAccess.Repository.IRepository;
using MusicS.Models;
using MusicS.Models.ViewModels;
using System.Diagnostics;

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
        public IActionResult Details(int id)
        {
            ShoppingCart cartObj = new()
            {
                Count=1,
                Album = _unitOfWork.Album.GetFirstOrDefault(u=>u.Id==id, includeProperties:"Genre")
            };
            return View(cartObj);
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
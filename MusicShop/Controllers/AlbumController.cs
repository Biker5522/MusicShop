using Microsoft.AspNetCore.Mvc;

namespace MusicShop.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

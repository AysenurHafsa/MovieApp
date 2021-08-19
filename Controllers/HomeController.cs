using Microsoft.AspNetCore.Mvc;

//kullanıcı sayfaları için homecontrollerı kullanırız

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
         public IActionResult Index()
         {
             //kullanıcı onaylı olan movie bilgilerini ekranda görebillir,
        return View();
         }
         public IActionResult Contact()
         {
             //
             return View();
         }
         
    }
}
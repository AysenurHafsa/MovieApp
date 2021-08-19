
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//yönetici sayfaları için homecontrollerı kullanırız

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
         public IActionResult Index()
         {
           //bütün movie bilgilerini gösterme
           return View();
         }

         public IActionResult Create()
         {
           //yeni bir movie yeni bit movie oluştırma
           return View();
         }

         public IActionResult Details()
         {
           //herhangi bir kaydın detay bilgilerin
           return View();
         }

         public IActionResult List()
         {
           //
           return View();
         }
    }
}
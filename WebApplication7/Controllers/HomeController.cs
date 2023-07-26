using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CharacterCollection chars = new CharacterCollection();
            List<Character> characters = chars.FindAllCharacters();

            List<Character> randomized = GetRandomCharacters(characters, 2);
            // Now, 'randomized' contains two random elements from 'characters' list.

            Console.WriteLine(characters.Count);
            return View(randomized); // Return the randomized list to the view.
        }

        public List<Character> GetRandomCharacters(List<Character> characters, int count)
        {
            Random rnd = new Random();
            List<Character> randomizedCharacters = characters.OrderBy(x => rnd.Next()).Take(count).ToList();
            return randomizedCharacters;
        }

        [HttpPost]
        public JsonResult HandleButtonClick()
        {
            string hola = "das";
            return Json(hola);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
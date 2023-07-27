using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string errorMessage = TempData["ErrorMessage"] as string;
            if (!string.IsNullOrEmpty(errorMessage))
            {
                // Pass the error message to the view.
                ViewBag.ErrorMessage = errorMessage;
            }
          
            string loser = TempData["Loser"] as string;
            if (!string.IsNullOrEmpty(loser))
            {
                // Pass the error message to the view.
                ViewBag.Loser = loser;
            }
            string winner = TempData["Winner"] as string;
            if (!string.IsNullOrEmpty(winner))
            {
                // Pass the error message to the view.
                ViewBag.Winner = winner;
            }
            string counter = TempData["Counter"] as string;
            if (!string.IsNullOrEmpty(counter))
            {
                // Pass the error message to the view.
                ViewBag.Counter = counter;
            }
            CharacterCollection chars = new CharacterCollection();
            List<Character> characters = chars.FindAllCharacters();

            List<Character> randomized = GetRandomCharacters(characters, 2);
            // Now, 'randomized' contains two random elements from 'characters' list.

            return View(randomized); // Return the randomized list to the view.
        }

        public List<Character> GetRandomCharacters(List<Character> characters, int count)
        {
            Random rnd = new Random();
            List<Character> randomizedCharacters = characters.OrderBy(x => rnd.Next()).Take(count).ToList();
            return randomizedCharacters;
        }

        public bool CheckFormIsCorrect(string winner, string char_0, string char_1)
        {
            // Check if player choices are not empty and if the winner is one of the players.
            bool players_exist = !string.IsNullOrEmpty(char_0) && !string.IsNullOrEmpty(char_1);
            bool winnerIsAPlayer = winner == char_0 || winner == char_1;

            // The form is correct if both conditions are met.
            return players_exist && winnerIsAPlayer;
        }



        [HttpPost]
        public RedirectToRouteResult HandleButtonClick()
        {
            string winner = Request.Form.Get("winner");
            string char_0 = Request.Form.Get("Character0");
            string char_1 = Request.Form.Get("Character1");
            bool ok = CheckFormIsCorrect(winner, char_0, char_1);
            if (ok)
            {
                CharacterCollection finder = new CharacterCollection();
                Character character_0 = finder.FindCharacterById(char_0);
                Character character_1 = finder.FindCharacterById(char_1);
                if (character_0 != null || character_1!=null)
                {
                    bool char_0_winner =  (character_0.Views) > (character_1.Views);
                    if (winner == character_0.Id)
                    {
                        TempData["Winner"] = $"You won {character_0.Name} has {character_0.Views} views and {character_1.Name} has {character_1.Views}";
                        
                        
                          
                        int counter = 0;
                        if (Session["Counter"] != null)
                        {
                            counter = (int)Session["Counter"];
                        }

                        counter++;

                        Session["Counter"] = counter;

                        Console.WriteLine("The current counter is: " + counter);
                    }
                    else
                    {
                        TempData["Loser"] = $"You lost {character_0.Name} has {character_0.Views} views and {character_1.Name} has {character_1.Views}";
                        Session["Counter"] = 0;

                    }
                    
                }
                
            }
            else
            {
                string error = "There was an error with the form."; // Change the error message as needed.
                TempData["ErrorMessage"] = error;
            }
    
            // Redirect to the Index action in HomeController.
            return RedirectToRoute(new { controller = "Home", action = "Index" });
         
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
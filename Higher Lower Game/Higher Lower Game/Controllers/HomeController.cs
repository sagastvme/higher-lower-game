using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Higher_Lower_Game.Models;

namespace Higher_Lower_Game.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        CharacterViewModel[] array = new CharacterViewModel[]
        {
            new CharacterViewModel(2, "Edu", 40),
            new CharacterViewModel(3, "Alice", 25)
        };
        return View(array);
    }
    [HttpPost]
    public IActionResult HandleButtonClick(int selectedCharacter)
    {
        // Here, you can process the data received from the form submission.
        // 'selectedCharacter' will contain the 'Views' value of the selected character.
        // Perform the necessary logic based on the selected character.

        // For demonstration purposes, we'll just return a simple message.
        return Content($"You selected a character with {selectedCharacter} views.");
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
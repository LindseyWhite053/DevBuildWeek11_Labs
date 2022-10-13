using Lab2_StarWarsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab2_StarWarsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        async public Task<IActionResult> FilmDetails(int episode)
        {
            if (episode == 0)
            {
                return Redirect("index");
            }
            else
            {
            Movie selectedMovie = await StarWarsAPI.GetMovie((episode));

            return View(selectedMovie);
            }
            

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
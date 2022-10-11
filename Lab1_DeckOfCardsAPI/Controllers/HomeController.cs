using Lab1_DeckOfCardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab1_DeckOfCardsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        async public Task<IActionResult> Index()
        {
            HttpClient web = new HttpClient();
            web.BaseAddress = new Uri("https://www.deckofcardsapi.com/");
            var connection = await web.GetAsync("api/deck/new/draw/?count=5");
            CardResponse res = await connection.Content.ReadAsAsync<CardResponse>();

            return View(res);
        }

        async public Task<IActionResult> Draw(string deck_id)
        {
           
            HttpClient web = new HttpClient();
            web.BaseAddress = new Uri("https://www.deckofcardsapi.com/");
            var connection = await web.GetAsync($"api/deck/{deck_id}/draw/?count=5");
            CardResponse res = await connection.Content.ReadAsAsync<CardResponse>();
            return View(res);
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
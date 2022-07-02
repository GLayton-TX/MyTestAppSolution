using Microsoft.AspNetCore.Mvc;
using MyTestApp.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MyTestApp.Controllers
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

        [HttpGet]
        public IActionResult Palindrome()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Palindrome(Palindrome palindrome)
        {
            //do validation
            if (!ModelState.IsValid)
            {
                return View(palindrome);
            }
            //Run code
            string inputWord = palindrome.InputWord;
            string revWord = "";
            for (int i = inputWord.Length; i > 0; i--)
            {
                revWord += inputWord[i - 1];
            }
            palindrome.RevWord = revWord;
            revWord = Regex.Replace(revWord.ToLower(), "[^a-zA-Z0-9]+", "");
            inputWord = Regex.Replace(revWord.ToLower(), "[^a-zA-Z0-9]+", "");
            if (revWord == inputWord)
            {
                palindrome.IsPalindrome = true;
                palindrome.Message = $"Success {palindrome.InputWord} is a Palindrome!";
            }
            else
            {
                palindrome.IsPalindrome = false;
                palindrome.Message = $"Sorry {palindrome.InputWord} is not a Palindrome.";
            }

            // redirect
            return View("AppView", palindrome);
        }

        public IActionResult AppView(Palindrome palindrome)
        {
            return View(palindrome);
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
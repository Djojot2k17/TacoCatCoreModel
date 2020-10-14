using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TacoCatCoreModel.Models;

namespace TacoCatCoreModel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();
        public IActionResult Code() => View();
        public IActionResult Solve() => View();
        [HttpPost]
        public IActionResult Solve(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return View();
            }

            var tacoModel = new TacoCat
            {
                Input = input,
                Output = string.Join("", input.Reverse().ToArray())
            };

            if (tacoModel.Input == tacoModel.Output)
            {
                tacoModel.Palindrome = true;
            }


            return View("Result", tacoModel);
        }
        public IActionResult Result(TacoCat model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

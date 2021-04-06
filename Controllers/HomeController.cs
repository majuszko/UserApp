using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserApp.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace UserApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private UserManager<AppUser> userManager;

        

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userMgr)
        {
            _logger = logger;
            userManager = userMgr;
        }
        /*[Authorize]
        public IActionResult Index()
        {
            
            return View((object)"Hello");
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

        [ActivatorUtilitiesConstructor]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            int time = DateTime.Now.Hour;

            string message = "Hello there, Admin " + user.UserName;


            return View((object)message);
        }

    }
}

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
//using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserApp.Controllers
{
    public class ProfileController : Controller
    {
        private UserManager<AppUser> userManager;

        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger, UserManager<AppUser> userMgr)
        {
            _logger = logger;
            userManager = userMgr;
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Accounts()
        {
            return View(userManager.Users);
        }

        [Authorize]
        public async Task<IActionResult> ProfileView(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            User usr = new User();
            //AppUser user = await userManager.GetUserAsync(HttpContext.User);
            //var userId = await userManager.GetUserIdAsync(HttpContext.User);
            //string username = "This is " + user.UserName+ "'s Profile";
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserApp.Models;
using UserApp.Controllers;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserApp.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private UserManager<AppUser> userManager;
        public readonly ApplicationDbContext _context;
        private readonly ILogger<ChatController> _logger;

        public ChatController(ApplicationDbContext context, ILogger<ChatController> logger, UserManager<AppUser> userMgr)
        {
            _logger = logger;
            userManager = userMgr;
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;
            }
            var messages = await _context.Messages.ToListAsync();
            return View(messages); 
        }

        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                message.Username = User.Identity.Name;
                var sender = await userManager.GetUserAsync(User);
                message.UserID = sender.Id;
                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return Error();
            
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
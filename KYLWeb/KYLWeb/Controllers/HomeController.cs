using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KYLWeb.Models;
using BLL;
using DAL;

namespace KYLWeb.Controllers
{
    public class HomeController : Controller
    {
        PlayContext playContext = new PlayContext();
        UserContext userContext = new UserContext();
        private readonly PlayManager pm;
        private readonly UserManager um;

        public HomeController()
        {
            pm = new PlayManager(playContext);
            um = new UserManager(userContext);
        }
        public IActionResult Index()
        {
            User user = um.GetUserById(1);
            List<Play> plays = user.Plays;
            return View(plays);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Play play = pm.GetPlayById(id);
            return View(play);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Play play)
        {
            Play addedPlay = pm.AddPlayInDB(play);

            return RedirectToAction("Details", new { id = addedPlay.Id});
        }

    }
}

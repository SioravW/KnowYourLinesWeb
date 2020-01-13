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
        UserCollectionData userContext = new UserCollectionData();
        private readonly PlayManager pm;
        private readonly UserCollection userCollection;

        public HomeController()
        {
            pm = new PlayManager(playContext);
            userCollection = new UserCollection(userContext);
        }
        public IActionResult Index()
        {
            User user = userCollection.GetUserById(1);
            List<Play> plays = user.Plays;
            return View(plays);
        }

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

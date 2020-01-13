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
        UserData userContext = new UserData();
        UserCollectionData userCollectionContext = new UserCollectionData();
        private readonly User user;
        private readonly UserCollection userCollection;

        public HomeController()
        {
            user = new User(userContext);
            userCollection = new UserCollection(userCollectionContext);
        }
        public IActionResult Index()
        {
            User user = userCollection.GetUserById(1);
            List<Play> plays = user.Plays;
            return View(plays);
        }

        public IActionResult Details(int id)
        {
            Play play = user.GetPlayById(id);
            return View(play);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Play play)
        {
            Play addedPlay = user.AddPlayInDB(play);

            return RedirectToAction("Details", new { id = addedPlay.Id});
        }

    }
}

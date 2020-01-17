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
using Microsoft.AspNetCore.Http;

namespace KYLWeb.Controllers
{
    public class HomeController : Controller
    {
        UserData userData = new UserData();
        UserCollectionData userCollectionData = new UserCollectionData();
        private readonly User user;
        private readonly UserCollection userCollection;

        public HomeController()
        {
            user = new User(userData);
            userCollection = new UserCollection(userCollectionData);
        }
        public IActionResult Index()
        {
            User user = userCollection.GetUserById(1);
            List<PlayViewModel> playViewModels = new List<PlayViewModel>();
            foreach(Play play in user.Plays)
            {
                PlayViewModel pvm = new PlayViewModel
                {
                    Id = play.Id,
                    Title = play.Title,
                    Description = play.Description,
                    Association = this.user.GetAssociationById(play.AssociationId).Name,
                    Writer = userCollection.GetUserById(play.WriterId).FullName,
                };
                playViewModels.Add(pvm);
            }
            return View(playViewModels);
        }

        public IActionResult Details(int id)
        {
            Play play = user.GetPlayById(id);
            PlayViewModel pvm = new PlayViewModel
            {
                Id = play.Id,
                Title = play.Title,
                Description = play.Description,
                Association = user.GetAssociationById(play.AssociationId).Name,
                Writer = userCollection.GetUserById(play.WriterId).FullName,
            };
            ViewBag.Title = play.Title;
            return View(pvm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PlayViewModel playViewModel)
        {
            Play play = new Play
            {
                Title = playViewModel.Title,
                Description = playViewModel.Description,
                WriterId = 1
            };
            Play addedPlay = user.AddPlayInDB(play);

            return RedirectToAction("Details", new { id = addedPlay.Id});
        }
    }
}

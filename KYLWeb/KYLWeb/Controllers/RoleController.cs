using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using KYLWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace KYLWeb.Controllers
{
    public class RoleController : Controller
    {
        UserData userData = new UserData();
        UserCollectionData userCollectionData = new UserCollectionData();
        PlayData playData = new PlayData();
        SceneData sceneData = new SceneData();
        private readonly User user;
        private readonly UserCollection userCollection;
        private readonly Play play;
        private readonly Scene scene;

        public RoleController()
        {
            user = new User(userData);
            userCollection = new UserCollection(userCollectionData);
            play = new Play(playData);
            scene = new Scene(sceneData);
        }
        
        public IActionResult Roles(int id)
        {
            Play play = user.GetPlayById(id);
            List<RoleViewModel> roleViewModels = new List<RoleViewModel>();
            foreach (Role role in play.Roles)
            {
                RoleViewModel roleViewModel = new RoleViewModel { Id = role.Id, Name = role.Name, Description = role.Description, Player = userCollection.GetUserById(role.Player.Id).FullName };
                roleViewModels.Add(roleViewModel);
            }
            ViewBag.Play = play.Title;

            return View(roleViewModels);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleViewModel roleViewModel)
        {
            Role role = new Role
            {
                Name = roleViewModel.Name,
                Description = roleViewModel.Description
            };
            Role addedPlay = scene.AddRoleInDB(role);

            return RedirectToAction("Roles", new { id = });
        }
    }
}
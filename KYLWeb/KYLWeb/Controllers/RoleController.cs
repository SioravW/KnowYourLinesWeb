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
        private readonly User user;
        private readonly UserCollection userCollection;
        private readonly Play play;

        public RoleController()
        {
            user = new User(userData);
            userCollection = new UserCollection(userCollectionData);
            play = new Play(playData);
        }
        public IActionResult Index(int id)
        {
            Role role = play.GetRoleById(id);
            RoleViewModel roleViewModel = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                Player = userCollection.GetUserById(role.Player.Id).FullName
            };
            return View(roleViewModel);
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

            return View(roleViewModels);
        }
    }
}
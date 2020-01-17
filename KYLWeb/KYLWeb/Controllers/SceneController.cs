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
    public class SceneController : Controller
    {
        UserData userData = new UserData();
        UserCollectionData userCollectionData = new UserCollectionData();
        PlayData playData = new PlayData();
        private readonly User user;
        private readonly UserCollection userCollection;
        private readonly Play play;

        public SceneController()
        {
            user = new User(userData);
            userCollection = new UserCollection(userCollectionData);
            play = new Play(playData);
        }
        public IActionResult Scenes(int id)
        {
            Play play = user.GetPlayById(id);
            List<SceneViewModel> sceneViewModels = new List<SceneViewModel>();
            foreach (Scene scene in play.Scenes)
            {
                SceneViewModel sceneViewModel = new SceneViewModel { Id = scene.Id, Number = scene.Number, Name = scene.Name };
                sceneViewModels.Add(sceneViewModel);
            }
            ViewBag.Title = play.Title;
            return View(sceneViewModels);
        }

        public IActionResult Lines(int id)
        {
            Scene scene = play.GetSceneById(id);
            ViewBag.Name = scene.Name;
            List<LineViewModel> lines = new List<LineViewModel>();
            foreach(Line line in scene.Lines)
            {
                LineViewModel lineViewModel = new LineViewModel
                {
                    Id = line.Id,
                    Text = line.Text,
                    Index = line.Index,
                };
                String roles = "";
                foreach(Role role in line.Roles)
                {
                    if(roles != "")
                    {
                        roles = roles + ", ";
                    }
                    roles = roles + role.Name;
                }
                lineViewModel.Roles = roles;
                lines.Add(lineViewModel);
            }

            return View(lines);
        }

    }
}
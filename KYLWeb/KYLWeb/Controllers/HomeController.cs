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
        private readonly PlayManager pm;

        public HomeController()
        {
            pm = new PlayManager(playContext);
        }
        public IActionResult Index()
        {
            Play play = pm.GetPlayById(1);
            return View(play);
        }

    }
}

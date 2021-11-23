using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolProj.Context;
using SchoolProj.Models;
using SchoolProj.Models.ViewModels;
using SchoolProj.Reposotries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRegestrationDetailsInfo _repo;
        private MyDbContext db;




        public HomeController(IRegestrationDetailsInfo repo, MyDbContext db)
        {
            this._repo = repo;
            this.db = db;
        }

        public ActionResult Index()
        {
            return View();
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

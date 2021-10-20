using Microsoft.AspNetCore.Mvc;
using SchoolProj.Models;
using SchoolProj.Reposotries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepo roomRepo;

        public RoomController(IRoomRepo roomRepo)
        {
            this.roomRepo = roomRepo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Room> teacherslist = roomRepo.GetAllRooms();
            return View(teacherslist);
        }

        //Render Creation view
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            if(room != null)
                roomRepo.Create(room);

            List<Room> rooms = roomRepo.GetAllRooms();
            return View("Index",rooms);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if(id>0)
                roomRepo.Delete(id);

            List<Room> rooms = roomRepo.GetAllRooms();
            return View("Index", rooms);
        }

    }
}

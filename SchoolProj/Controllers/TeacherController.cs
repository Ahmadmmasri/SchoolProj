using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProj.Models;
using SchoolProj.Reposotries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepo teacherRepo;
        private readonly IHostingEnvironment environment;

        public TeacherController(ITeacherRepo teacherRepo)
        {
            this.teacherRepo = teacherRepo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Teacher> teacherslist = teacherRepo.GetAllTeachers();
            return View(teacherslist);
        }

        //Render Creation view
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher, IFormFile TeachePhoto)
        {

            if (teacher != null)
            {
                teacher.TeacherAge = (DateTime.Now.Year - teacher.DateBirth.Year).ToString();
                teacherRepo.Create(teacher);
            }

            List<Teacher> teacherslist = teacherRepo.GetAllTeachers();
            return View("Index",teacherslist);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id > 0)
                teacherRepo.Delete(id);

            List<Teacher> teacherslist = teacherRepo.GetAllTeachers();
            return View("Index", teacherslist);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Teacher teacherDetailsEdit = teacherRepo.Edit(id);
            if (teacherDetailsEdit != null)
            {
                return View(teacherDetailsEdit);
            }
            else
                return Content("Page not found");
        }

        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {
            if(ModelState.IsValid && teacher!= null)
                teacherRepo.Edit(teacher);
            return RedirectToAction("Index");
        }   
        

    }
}

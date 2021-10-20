using Microsoft.AspNetCore.Mvc;
using SchoolProj.Models;
using SchoolProj.Reposotries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepo courseRepo;
        private readonly ITeacherRepo teacherRepo;

        public CourseController(ICourseRepo courseRepo , ITeacherRepo teacherRepo)
        {
            this.courseRepo = courseRepo;
            this.teacherRepo = teacherRepo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Course> Courseslist = courseRepo.GetAllCourses();
            return View(Courseslist);
        }

        //Render Creation view
        [HttpGet]
        public ViewResult Create()
        {
            List<Teacher> Teacherlist = teacherRepo.GetAllTeachers();

            return View(Teacherlist);
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if(course != null)
                courseRepo.Create(course);
            List<Course> Courseslist = courseRepo.GetAllCourses();
            return View("Index", Courseslist);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if(id>0)
                courseRepo.Delete(id);
            return View();
        }



    }
}

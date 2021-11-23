using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProj.Context;
using SchoolProj.Models;
using SchoolProj.Models.ViewModels;
using SchoolProj.Reposotries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchoolProj.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepo studentRepo;
        private readonly ICourseRepo courseRepo;
        private readonly IRoomRepo roomRepo;
        private readonly IHostingEnvironment environment;
        private readonly IRegestrationDetailsInfo regestrationDetails;
        private readonly MyDbContext _dbcontext;

        public StudentController(MyDbContext dbcontext, IStudentRepo studentRepo, ICourseRepo courseRepo,IRoomRepo roomRepo, IHostingEnvironment environment, IRegestrationDetailsInfo regestrationDetails)
        {
            this.studentRepo = studentRepo;
            this.courseRepo = courseRepo;
            this.roomRepo = roomRepo;
            this.environment = environment;
            this.regestrationDetails = regestrationDetails;
            this._dbcontext = dbcontext;
        }

        [HttpGet]
        public ActionResult Index()
        {
            //state managment
            // session , cookies ,hidden field , query string , viewbag , tempdata ,viewdata

            List<Student> studentlist =  studentRepo.GetAllStudents();
            return View(studentlist);
        }

        //Render Creation view
        [HttpGet]
        public ViewResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student, IFormFile StudentPhoto)
        {
            //save pic in file
            var WWrootpath = environment.WebRootPath + "/StudentPhotos/";
            //Generate unique code  
            Guid guid = Guid.NewGuid();
            string path = System.IO.Path.Combine(WWrootpath,guid+ StudentPhoto.FileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                StudentPhoto.CopyTo(fileStream);
            };
            //end of save file
            if (student != null)
            {
                student.StudentPhoto = guid + StudentPhoto.FileName;
                student.StudentAge = DateTime.Now.Year - student.DateBirth.Year;
                studentRepo.Create(student);
            }
            List<Student> studentlist = studentRepo.GetAllStudents();


                return View("Index", studentlist);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if(id>0)
                studentRepo.Delete(id);

            List<Student> studentlist = studentRepo.GetAllStudents();
            return View("Index", studentlist);
        }

        [HttpGet]
        public ActionResult Register()
        {

            StudentCourseVM data = new StudentCourseVM();
            data.courses = courseRepo.GetAllCourses();
            data.students = studentRepo.GetAllStudents();
            data.rooms = roomRepo.GetAllRooms();
            ViewBag.result = HttpContext.Session.GetString("resultvalue");

            return View(data);

        }

        [HttpPost]
        public ActionResult Register( int studentId, int courseId, int roomId)
        {

            bool IsCreated = studentRepo.Register(studentId, courseId, roomId);
            bool? result= IsCreated == true ?  true : false;
            HttpContext.Session.SetString("resultvalue", result.ToString());

            return RedirectToAction("Register");
        }

        [HttpGet]
        public ActionResult AllRegerstration()
        {
            return View(regestrationDetails.GetAll());
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student studentDetailsEdit = studentRepo.Edit(id);
            if (studentDetailsEdit != null)
            {
                return View(studentDetailsEdit);
            }
            else
                return Content("Page not found");
        }

        [HttpPost]
        public ActionResult Edit(Student student,IFormFile StudentPhoto)
        {
            //save pic in file
            var WWrootpath = environment.WebRootPath + "/StudentPhotos/";
            //Generate unique code  
            Guid guid = Guid.NewGuid();
            string path = System.IO.Path.Combine(WWrootpath, guid + StudentPhoto.FileName);
          

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                StudentPhoto.CopyTo(fileStream);
            };

            if (student != null)
            {
                student.StudentPhoto = guid + StudentPhoto.FileName;
                studentRepo.Edit(student);
            }
            return RedirectToAction("Index");
        }


    }
}

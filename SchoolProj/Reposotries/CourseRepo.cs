using SchoolProj.Context;
using SchoolProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Reposotries
{
    public class CourseRepo : ICourseRepo
    {
        private readonly MyDbContext dbconnnection;

        public CourseRepo(MyDbContext dbcontext)
        {
            this.dbconnnection = dbcontext;
        }

        public void Create(Course course)
        {
            dbconnnection.courses.Add(course);
            dbconnnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Course course = dbconnnection.courses.Where(x => x.CourseId == id).FirstOrDefault();
            dbconnnection.courses.Remove(course);
            dbconnnection.SaveChanges();
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = dbconnnection.courses.ToList();
            return courses;
        }
    }
}

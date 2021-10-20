using SchoolProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Reposotries
{
     public interface ICourseRepo
    {
        public List<Course> GetAllCourses();
        public void Create(Course course);
        public void Delete(int id);
    }
}

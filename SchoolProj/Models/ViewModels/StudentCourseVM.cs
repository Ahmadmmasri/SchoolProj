using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Models.ViewModels
{
    public class StudentCourseVM
    {
      public List<Student> students { get; set; }
      public List<Course> courses { get; set; }
      public List<Room> rooms { get; set; }
    }
}

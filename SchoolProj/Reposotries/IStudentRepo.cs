using Microsoft.AspNetCore.Http;
using SchoolProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Reposotries
{
   public interface IStudentRepo
    {
        public List<Student> GetAllStudents();
        public List<StudentCourse> GetAllRegestration();
        public void Create(Student student);
        public void Delete(int StudentId);
        public void Register(int studentId, int courseId , int roomId);
        public void Edit(Student student);
        public Student Edit(int id);

    }
}

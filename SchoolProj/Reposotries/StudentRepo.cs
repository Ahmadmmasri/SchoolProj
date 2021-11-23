using SchoolProj.Context;
using SchoolProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Reposotries
{
    public class StudentRepo : IStudentRepo
    {
        private readonly MyDbContext dbconnnection;

        public StudentRepo(MyDbContext dbcontext)
        {
            this.dbconnnection = dbcontext;
        }

        public void Create(Student student)
        {
            dbconnnection.students.Add(student);
            dbconnnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Student student = dbconnnection.students.Where(x => x.StudentId == id).FirstOrDefault();
            dbconnnection.students.Remove(student);
            dbconnnection.SaveChanges();
            
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = dbconnnection.students.ToList();
                return students;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool Register(int studentId, int courseId, int roomId)
        {
            StudentCourse std = new StudentCourse();
            std.CourseID = courseId;
            std.StudentId = studentId;
            std.RoomId = roomId;
            std.RegestrationDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var IsStudentInCourse = dbconnnection.studentCourses.Where(x => x.StudentId == studentId && x.CourseID == courseId).FirstOrDefault();
            if (IsStudentInCourse==null)
            {
                dbconnnection.studentCourses.Add(std);
                dbconnnection.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<StudentCourse> GetAllRegestration()
        {
            try
            {
                List<StudentCourse> AllReg = dbconnnection.studentCourses.ToList();
                return AllReg;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Edit(Student student)
        {
            Student OldStudentDetails = dbconnnection.students.Find(student.StudentId);
            student.StudentAge = DateTime.Now.Year - student.DateBirth.Year;
            dbconnnection.Entry(OldStudentDetails).CurrentValues.SetValues(student);
            dbconnnection.SaveChanges();
        }

        public Student Edit(int id)
        {
            var StudentDetails = dbconnnection.students.Where(x => x.StudentId == id).FirstOrDefault();
            return StudentDetails;
        }

    }
}

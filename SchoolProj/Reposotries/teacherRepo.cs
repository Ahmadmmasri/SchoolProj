using Microsoft.EntityFrameworkCore;
using SchoolProj.Context;
using SchoolProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Reposotries
{
    public class teacherRepo : ITeacherRepo
    {
        private readonly MyDbContext dbconnnection;

        public teacherRepo(MyDbContext dbcontext)
        {
            this.dbconnnection = dbcontext;
        }

        public void Create(Teacher teacher)
        {
            dbconnnection.teachers.Add(teacher);
            dbconnnection.SaveChanges();
        }

        public void Delete(int teacherId)
        {
            Teacher teacher = dbconnnection.teachers.Where(x => x.TeacherId == teacherId).FirstOrDefault();
            dbconnnection.teachers.Remove(teacher); 
        }

        public void Edit(Teacher teacher)
        {
            Teacher OldTeacherDetails = dbconnnection.teachers.Find(teacher.TeacherId);
            teacher.TeacherAge = (DateTime.Now.Year- teacher.DateBirth.Year).ToString();
            dbconnnection.Entry(OldTeacherDetails).CurrentValues.SetValues(teacher);
            dbconnnection.SaveChanges();
        }

        public Teacher Edit(int id)
        {
            var TeacherDetails = dbconnnection.teachers.Where(x=>x.TeacherId==id).FirstOrDefault();
            return TeacherDetails;
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teacherList = dbconnnection.teachers.ToList();
            return teacherList;
        }

    }
}

using SchoolProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Reposotries
{
   public interface ITeacherRepo
    {
        public List<Teacher> GetAllTeachers();
        public void Create(Teacher teacher);
        public void Delete(int teacherId);
        public void Edit(Teacher teacher);
        public Teacher Edit(int id);
  
    }
}

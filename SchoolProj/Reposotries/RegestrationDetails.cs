using SchoolProj.Context;
using SchoolProj.Models;
using SchoolProj.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Reposotries
{
    public class RegestrationDetailsInfo : IRegestrationDetailsInfo
    {

        private readonly MyDbContext _dbcontext;

        public RegestrationDetailsInfo(MyDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public List<RegestrationDetails> GetAll()
        {
            var obj = from StdCourse in _dbcontext.studentCourses
                      join st in _dbcontext.students
                      on StdCourse.StudentId equals st.StudentId
                      join pt in _dbcontext.courses
                      on StdCourse.CourseID equals pt.CourseId
                      join pr in _dbcontext.rooms
                      on StdCourse.RoomId equals pr.RoomId
                      select new
                      {
                          pt.CourseName,
                          st.StudentName,
                          pr.RoomId,
                          StdCourse.RegestrationDate,
                      };


           var AllRegestrations = new List<RegestrationDetails>();


            foreach (var item in obj)
            {
                AllRegestrations.Add(
                    new RegestrationDetails { StudentName = item.StudentName, CoursetName = item.CourseName, roomId = item.RoomId, RegestrationDate= item.RegestrationDate }
                    );
            }



            return AllRegestrations.ToList();
        }
    }
}

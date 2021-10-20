using SchoolProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Reposotries
{
   public interface IRoomRepo
    {
        public List<Room> GetAllRooms();
        public void Create(Room room);
        public void Delete(int id);
    }
}

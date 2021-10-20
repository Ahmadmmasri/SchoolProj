using SchoolProj.Context;
using SchoolProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Reposotries
{
    public class RoomRepo : IRoomRepo
    {
        private readonly MyDbContext dbconnection;

        public RoomRepo(MyDbContext dbcontext)
        {
            this.dbconnection = dbcontext;
        }

        public void Create(Room room)
        {
            dbconnection.rooms.Add(room);
            dbconnection.SaveChanges();
        }

        public void Delete(int id)
        {

            Room room = dbconnection.rooms.Where(x => x.RoomId == id).FirstOrDefault();
            dbconnection.rooms.Remove(room);
            dbconnection.SaveChanges();
        }

        public List<Room> GetAllRooms()
        {
            List<Room> roomsList = dbconnection.rooms.ToList();
            return roomsList;
        }
    }
}

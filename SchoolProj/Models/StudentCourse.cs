using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Models
{
    public class StudentCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentCourseId { get; set; }

        //init foriegn key for Student
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        //end of foriegn key


        //init foriegn key for Course
        [Required]
        public int CourseID { get; set; }

        public Course Course { get; set; }

        //end of foriegn key

        //init foriegn key for Room
        [Required]

        public int RoomId { get; set; }

        public Room Room { get; set; }

        //end of foriegn key

        public DateTime RegestrationDate { get; set; }
    }
}

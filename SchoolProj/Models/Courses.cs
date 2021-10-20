using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProj.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [MinLength(10)]
        [MaxLength(30)]
        public string CourseName { get; set; }


        [Range(10, 20)]
        public string CourseCapacity { get; set; }


        //foriegn key init
        public int TeacherID { get; set; }

        public Teacher Teacher { get; set; }
        //end of foriegn key


        public string CoursePhoto { get; set; }

    }
}

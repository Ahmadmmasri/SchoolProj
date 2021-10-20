using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProj.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        public string TeacherName { get; set; }

        [Range(21,60)]
        public string TeacherAge { get; set; }

        public DateTime DateBirth { get; set; }


    }
}

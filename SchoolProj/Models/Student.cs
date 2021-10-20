using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProj.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        public string StudentName { get; set; }
        public bool IsActive { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateBirth { get; set; }
        
        [Range(5,18)]
        public int StudentAge { get; set; }
        public string StudentPhoto { get; set; }

    }
}

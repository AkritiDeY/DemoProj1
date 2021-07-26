using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DemoProj1.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string DeptName { get; set; }
        public int DeptStrength { get; set; }

    }
}

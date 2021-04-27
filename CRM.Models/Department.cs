using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRM.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Department Name")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

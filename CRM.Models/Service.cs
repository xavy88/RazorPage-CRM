﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Models
{
    public class Service
    {
     public int Id { get; set; }
     [Required]
     public string Name { get; set; }
     public double Price { get; set; }
     public string Description { get; set; }
     [Display(Name = "Department")]
     public int DepartmentId { get; set; }
     [ForeignKey("DepartmentId")]
     public virtual Department Department { get; set; }
    }
}

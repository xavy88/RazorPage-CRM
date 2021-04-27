using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Models
{
    public class TaskAssignment
    {
        public TaskAssignment()
        {
            StartDate = DateTime.Now;
        }
        public int Id { get; set; }
        [Display(Name = "Account")]
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        [Display(Name = "Task")]
        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public virtual Task Task { get; set; }
        [Display(Name = "Assignee")]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Due Date")]
        public DateTime DueDate { get; set; }
        public string Notes { get; set; }
        public bool Completed { get; set; }


    }
}

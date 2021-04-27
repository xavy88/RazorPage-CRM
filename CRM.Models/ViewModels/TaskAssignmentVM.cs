using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models.ViewModels
{
    public class TaskAssignmentVM
    {
        public TaskAssignment TaskAssignment { get; set; }
        public IEnumerable<SelectListItem> AccountList { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
        public IEnumerable<SelectListItem> TaskList { get; set; }
        public IEnumerable<SelectListItem> ApplicationUserList { get; set; }
    }
}

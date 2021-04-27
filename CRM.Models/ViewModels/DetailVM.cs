using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models.ViewModels
{
    public class DetailVM
    {
        public Detail Detail { get; set; }
        public IEnumerable<SelectListItem> OrderList { get; set; }
        public IEnumerable<SelectListItem> AccountList { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
        public IEnumerable<SelectListItem> ServiceList { get; set; }
        public IEnumerable<SelectListItem> ApplicationUserList { get; set; }
        public IEnumerable<SelectListItem> EmployeeList { get; set; }


    }

}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models.ViewModels
{
    public class PositionVM
    {
        public Position Position { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models.ViewModels
{
    public class ContactVM
    {
        public Contact Contact { get; set; }
        public IEnumerable<SelectListItem> AccountList { get; set; }
    }
}

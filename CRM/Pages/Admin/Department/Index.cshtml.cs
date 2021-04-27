using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRM.Pages.Admin.Department
{
   // [Authorize(Roles = SD.ManagerRole + "," + SD.RootRole)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

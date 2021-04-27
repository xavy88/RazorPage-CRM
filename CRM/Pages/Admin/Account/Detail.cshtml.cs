using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using CRM.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRM.Pages.Admin.Account
{
    public class DetailModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
        }
        //Using the below code is not necessary to declare into de Post method
        [BindProperty]
        public Models.Account AccountObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            AccountObj = new Models.Account();
        
            if (id!=null)
            {
                AccountObj = _unitOfWork.Account.GetFirstOrDefault(u => u.Id == id);
                if (AccountObj==null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (AccountObj.Id!=0)
            {
                _unitOfWork.Account.Disable(AccountObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

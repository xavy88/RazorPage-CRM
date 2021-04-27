using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRM.Pages.Admin.Department
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //Using the below code is not necessary to declare into de Post method
        [BindProperty]
        public Models.Department DepartmentObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            DepartmentObj = new Models.Department();
            if (id!=null)
            {
                DepartmentObj = _unitOfWork.Department.GetFirstOrDefault(u => u.Id == id);
                if (DepartmentObj==null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost(/*Models.Department DeparmentObj*/)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (DepartmentObj.Id==0)
            {
                _unitOfWork.Department.Add(DepartmentObj);
            }
            else
            {
                _unitOfWork.Department.Update(DepartmentObj);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

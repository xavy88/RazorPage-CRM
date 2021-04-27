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

namespace CRM.Pages.Admin.Employee
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
        public EmployeeVM EmployeeObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            EmployeeObj = new EmployeeVM
            {
                DepartmentList = _unitOfWork.Department.GetDepartmentListForDropDown(),
                PositionList = _unitOfWork.Position.GetPositionListForDropDown(),
                Employee = new Models.Employee()
            };
            if (id!=null)
            {
                EmployeeObj.Employee = _unitOfWork.Employee.GetFirstOrDefault(u => u.Id == id);
                if (EmployeeObj==null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
          
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            if (EmployeeObj.Employee.Id!=0)
            {
                _unitOfWork.Employee.Disable(EmployeeObj.Employee);
            }
           
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

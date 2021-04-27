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

namespace CRM.Pages.Supervisor.Task
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
        public TaskVM TaskObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            TaskObj = new TaskVM
            {
                DepartmentList = _unitOfWork.Department.GetDepartmentListForDropDown(),
                PositionList = _unitOfWork.Position.GetPositionListForDropDown(),
                Task = new Models.Task()
            };
            if (id != null)
            {
                TaskObj.Task = _unitOfWork.Task.GetFirstOrDefault(u => u.Id == id);
                if (TaskObj.Task == null)
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
            if (TaskObj.Task.Id == 0)
            {
                _unitOfWork.Task.Add(TaskObj.Task);
            }
            else
            {

               //Edit a Employee
                var objFromDb = _unitOfWork.Task.Get(TaskObj.Task.Id);
                 //_unitOfWork.Employee.Add(EmployeeObj.Employee);
           
                 _unitOfWork.Task.Update(TaskObj.Task);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

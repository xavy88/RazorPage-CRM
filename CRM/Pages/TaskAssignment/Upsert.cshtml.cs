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

namespace CRM.Pages.TaskAssignment
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
        public TaskAssignmentVM TaskAssignmentObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            TaskAssignmentObj = new TaskAssignmentVM
            {
                DepartmentList = _unitOfWork.Department.GetDepartmentListForDropDown(),
                AccountList = _unitOfWork.Account.GetAccountListForDropDown(),
                TaskList = _unitOfWork.Task.GetTaskListForDropDown(),
                ApplicationUserList = _unitOfWork.ApplicationUser.GetApplicationUserListForDropDown(),
                TaskAssignment = new Models.TaskAssignment()
            };
            if (id!=null)
            {
                TaskAssignmentObj.TaskAssignment = _unitOfWork.TaskAssignment.GetFirstOrDefault(u => u.Id == id);
                if (TaskAssignmentObj.TaskAssignment==null)
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
            if (TaskAssignmentObj.TaskAssignment.Id == 0)
            {
                _unitOfWork.TaskAssignment.Add(TaskAssignmentObj.TaskAssignment);
            }
            else
            {
                _unitOfWork.TaskAssignment.Update(TaskAssignmentObj.TaskAssignment);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

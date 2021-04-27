using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using CRM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRM.Pages.TaskAssignment
{
    public class DetailModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailModel(IUnitOfWork unitOfWork)
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
                TaskList = _unitOfWork.Task.GetTaskListForDropDown(),
                ApplicationUserList = _unitOfWork.ApplicationUser.GetApplicationUserListForDropDown(),
                AccountList = _unitOfWork.Account.GetAccountListForDropDown(),
                TaskAssignment = new Models.TaskAssignment()
            };
            if (id!=null)
            {
                TaskAssignmentObj.TaskAssignment = _unitOfWork.TaskAssignment.GetFirstOrDefault(u => u.Id == id);
                if (TaskAssignmentObj == null)
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
            if (TaskAssignmentObj.TaskAssignment.Id!=0)
            {
                _unitOfWork.TaskAssignment.Completed(TaskAssignmentObj.TaskAssignment);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
        
    }
}

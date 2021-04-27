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

namespace CRM.Pages.Sale.Detail
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
        public DetailVM DetailObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            DetailObj = new DetailVM
            {
                OrderList = _unitOfWork.Order.GetOrderListForDropDown(),
                AccountList = _unitOfWork.Account.GetAccountListForDropDown(),
                DepartmentList = _unitOfWork.Department.GetDepartmentListForDropDown(),
                ApplicationUserList = _unitOfWork.ApplicationUser.GetApplicationUserListForDropDown(),
                ServiceList = _unitOfWork.Service.GetServiceListForDropDown(),
                EmployeeList = _unitOfWork.Employee.GetEmployeeListForDropDown(),
                Detail = new Models.Detail()
            };
            if (id!=null)
            {
                DetailObj.Detail = _unitOfWork.Detail.GetFirstOrDefault(u => u.Id == id);
                if (DetailObj.Detail==null)
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
            if (DetailObj.Detail.Id==0)
            {
                _unitOfWork.Detail.Add(DetailObj.Detail);
            }
            else
            {
                _unitOfWork.Detail.Update(DetailObj.Detail);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

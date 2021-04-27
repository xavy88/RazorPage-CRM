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

namespace CRM.Pages.Supervisor.Service
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
        public ServiceVM ServiceObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            ServiceObj = new ServiceVM
            {
                DepartmentList = _unitOfWork.Department.GetDepartmentListForDropDown(),
                Service= new Models.Service()
            };
            if (id!=null)
            {
                ServiceObj.Service = _unitOfWork.Service.GetFirstOrDefault(u => u.Id == id);
                if (ServiceObj.Service==null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

    }
}

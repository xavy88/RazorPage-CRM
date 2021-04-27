using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRM.Pages.Supervisor.Position
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
        public PositionVM PositionObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            PositionObj = new PositionVM
            {
                DepartmentList = _unitOfWork.Department.GetDepartmentListForDropDown(),
                Position = new Models.Position()
            };
            if (id != null)
            {
                PositionObj.Position = _unitOfWork.Position.GetFirstOrDefault(u => u.Id == id);
                if (PositionObj.Position == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

    }
}

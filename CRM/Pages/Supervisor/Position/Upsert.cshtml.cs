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
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
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

        public IActionResult OnPost(/*Models.Department DeparmentObj*/)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (PositionObj.Position.Id == 0)
            {
                _unitOfWork.Position.Add(PositionObj.Position);
            }
            else
            {
                _unitOfWork.Position.Update(PositionObj.Position);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

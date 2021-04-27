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

namespace CRM.Pages.Supervisor.Contact
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
        public ContactVM ContactObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            ContactObj = new ContactVM
            {
                AccountList = _unitOfWork.Account.GetAccountListForDropDown(),
                Contact= new Models.Contact()
            };
            if (id!=null)
            {
                ContactObj.Contact = _unitOfWork.Contact.GetFirstOrDefault(u => u.Id == id);
                if (ContactObj.Contact==null)
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
            if (ContactObj.Contact.Id==0)
            {
                _unitOfWork.Contact.Add(ContactObj.Contact);
            }
            else
            {
                _unitOfWork.Contact.Update(ContactObj.Contact);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

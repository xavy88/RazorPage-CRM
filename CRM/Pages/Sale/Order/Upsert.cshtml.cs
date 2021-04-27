using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRM.Pages.Sale.Order
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
        public Models.Order OrderObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            OrderObj = new Models.Order();
            if (id!=null)
            {
                OrderObj = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);
                if (OrderObj==null)
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
            if (OrderObj.Id==0)
            {
                _unitOfWork.Order.Add(OrderObj);
            }
            else
            {
                _unitOfWork.Order.Update(OrderObj);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

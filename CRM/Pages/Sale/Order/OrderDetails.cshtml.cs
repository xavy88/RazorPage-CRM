using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRM.Pages.Sale.Order
{
    public class OrderDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public OrderDetailsVM orderDetails { get; set; }
        public void OnGet(int id)
        {
            orderDetails = new OrderDetailsVM()
            {
                Order = _unitOfWork.Order.GetFirstOrDefault(m => m.Id == id),
                Detail = _unitOfWork.Detail.GetAll(m => m.OrderId == id).ToList()

            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRM.Pages.User.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Order> OrderList { get; set; }
        public IEnumerable<Detail> DetailList { get; set; }
        //public IEnumerable<Position> PositionList { get; set; }
        public void OnGet()
        {
            DetailList = _unitOfWork.Detail.GetAll(null, q => q.OrderBy(c => c.DepartmentId), "Order,Account,Department,Service,ApplicationUser");
            OrderList = _unitOfWork.Order.GetAll(null, q => (IOrderedQueryable<Models.Order>)q.Where(c => c.Closed == false), null);
          
        }
    }
}

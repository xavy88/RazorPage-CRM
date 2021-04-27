using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Data.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<SelectListItem> GetOrderListForDropDown();
        void Update(Order order);
        void Closed(Order order);

    }
}

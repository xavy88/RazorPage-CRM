using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DataAccess.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetOrderListForDropDown()
        {
            return _db.Order.Where(i => i.Closed == false).Select(i => new SelectListItem()
            {
                Text = i.Reference,
                Value = i.Id.ToString()
            });
        }
        public void Closed(Order order)
        {
            var OrderFromDb = _db.Order.FirstOrDefault(m => m.Id == order.Id);

             OrderFromDb.Closed = true;
            _db.SaveChanges();
        }

        public void Update(Order order)
        {
            var OrderFromDb = _db.Order.FirstOrDefault(m => m.Id == order.Id);

            OrderFromDb.Reference = order.Reference;
            OrderFromDb.StartDate = order.StartDate;
            OrderFromDb.EndDate = order.EndDate;
            OrderFromDb.Comments = order.Comments;
            OrderFromDb.Closed = order.Closed;
            _db.SaveChanges();
        }
    }
}

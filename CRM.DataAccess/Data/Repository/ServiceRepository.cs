using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DataAccess.Data.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly ApplicationDbContext _db;
        public ServiceRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetServiceListForDropDown()
        {
            return _db.Services.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }
        public void Update(Service service)
        {
            var serviceFromDb = _db.Services.FirstOrDefault(m => m.Id == service.Id);

            serviceFromDb.Name = service.Name;
            serviceFromDb.DepartmentId = service.DepartmentId;
            serviceFromDb.Description = service.Description;
            serviceFromDb.Price = service.Price;

            _db.SaveChanges();
        }
    }
}

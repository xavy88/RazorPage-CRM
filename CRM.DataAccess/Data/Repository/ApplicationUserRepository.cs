using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DataAccess.Data.Repository
{
    public class ApplicationUserRepository: Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetApplicationUserListForDropDown()
        {
            return _db.ApplicationUser.Where(i => i.LockoutEnd == null).Select(i => new SelectListItem()
            {
                Text=i.Email,
                Value = i.Id.ToString()
            });
        }
        /*
        public void Update(Department department)
        {
            var objFromDb = _db.Department.FirstOrDefault(s => s.Id == department.Id);
            objFromDb.Name = department.Name;
            objFromDb.Description = department.Description;

            _db.SaveChanges();
        }
        */
    }
}

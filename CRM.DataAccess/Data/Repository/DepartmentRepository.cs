using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DataAccess.Data.Repository
{
    public class DepartmentRepository:Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;

        public DepartmentRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDepartmentListForDropDown()
        {
            return _db.Department.Select(i => new SelectListItem()
            {
                Text=i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Department department)
        {
            var objFromDb = _db.Department.FirstOrDefault(s => s.Id == department.Id);
            objFromDb.Name = department.Name;
            objFromDb.Description = department.Description;

            _db.SaveChanges();
        }
    }
}

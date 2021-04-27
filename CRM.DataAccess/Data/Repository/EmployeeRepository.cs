using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DataAccess.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetEmployeeListForDropDown()
        {
            return _db.Employee.Where(i => i.Status == false).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Disable(Employee employee)
        {
            var employeeFromDb = _db.Employee.FirstOrDefault(m => m.Id == employee.Id);

            employeeFromDb.Status = true;
            _db.SaveChanges();

        }
        public void Update(Employee employee)
        {
            var employeeFromDb = _db.Employee.FirstOrDefault(m => m.Id == employee.Id);

            employeeFromDb.Name = employee.Name;
            employeeFromDb.Email = employee.Email;
            employeeFromDb.Phone = employee.Phone;
            employeeFromDb.HiredDate = employee.HiredDate;
            employeeFromDb.PositionId = employee.PositionId;
            employeeFromDb.DepartmentId = employee.DepartmentId;
            employeeFromDb.Status = employee.Status;

            if (employee.Image!=null)
            {
                employeeFromDb.Image = employee.Image;
            }
            _db.SaveChanges();
            
          


        }
    }
}

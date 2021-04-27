using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Data.Repository.IRepository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        IEnumerable<SelectListItem> GetEmployeeListForDropDown();
        void Update(Employee employee);
        void Disable(Employee employee);
    }
}

using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRM.DataAccess.Data.Repository.IRepository
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        IEnumerable<SelectListItem> GetDepartmentListForDropDown();

        void Update(Department department);
    }
}

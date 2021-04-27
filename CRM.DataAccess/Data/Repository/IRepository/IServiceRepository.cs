using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Data.Repository.IRepository
{
    public interface IServiceRepository:IRepository<Service>
    {
        IEnumerable<SelectListItem> GetServiceListForDropDown();
        void Update(Service service);
    }
}

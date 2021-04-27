using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Data.Repository.IRepository
{
    public interface ITaskRepository : IRepository<Task>
    {
        IEnumerable<SelectListItem> GetTaskListForDropDown();
        void Update(Task task);
        void Disable(Task task);
    }
}

using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Data.Repository.IRepository
{
    public interface IPositionRepository:IRepository<Position>
    {
        IEnumerable<SelectListItem> GetPositionListForDropDown();
        void Update(Position position);
    }
}

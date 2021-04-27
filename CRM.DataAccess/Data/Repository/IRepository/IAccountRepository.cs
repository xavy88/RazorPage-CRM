using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Data.Repository.IRepository
{
    public interface IAccountRepository : IRepository<Account>
    {
        IEnumerable<SelectListItem> GetAccountListForDropDown();
        void Update(Account account);
        void Disable(Account account);
       
    }
}

using CRM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Data.Repository.IRepository
{
    public interface IContactRepository:IRepository<Contact>
    {
        void Update(Contact contact);
    }
}

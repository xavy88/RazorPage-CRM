using CRM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Data.Repository.IRepository
{
    public interface IDetailRepository : IRepository<Detail>
    {
        void Update(Detail detail);
        void Paid(Detail detail);

    }
}

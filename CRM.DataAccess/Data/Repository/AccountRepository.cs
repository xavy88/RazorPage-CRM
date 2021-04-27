using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DataAccess.Data.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly ApplicationDbContext _db;

        public AccountRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetAccountListForDropDown()
        {
            return _db.Account.Where(i=>i.Status==false).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Disable(Account account)
        {
            var accountFromDb = _db.Account.FirstOrDefault(m => m.Id == account.Id);

            accountFromDb.Status = true;
            _db.SaveChanges();
        }
        public void Update(Account account)
        {
            var accountFromDb = _db.Account.FirstOrDefault(m => m.Id == account.Id);

            accountFromDb.Name = account.Name;
            accountFromDb.Email = account.Email;
            accountFromDb.Phone = account.Phone;
            accountFromDb.SalesDate = account.SalesDate;
            accountFromDb.Website= account.Website;
            accountFromDb.Address = account.Address;
            accountFromDb.Description = account.Description;
            accountFromDb.Status = account.Status;

            if (account.Image!=null)
            {
                accountFromDb.Image = account.Image;
            }
            _db.SaveChanges();
            
          


        }
    }
}

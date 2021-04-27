using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DataAccess.Data.Repository
{
    public class DetailRepository : Repository<Detail>, IDetailRepository
    {
        private readonly ApplicationDbContext _db;

        public DetailRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Paid(Detail detail)
        {
            var DetailFromDb = _db.Detail.FirstOrDefault(m => m.Id == detail.Id);

             DetailFromDb.Paid = true;
            _db.SaveChanges();
        }

        public void Update(Detail detail)
        {
            var DetailFromDb = _db.Detail.FirstOrDefault(m => m.Id == detail.Id);

            DetailFromDb.PaymentID = detail.PaymentID;
            DetailFromDb.OrderId = detail.OrderId;
            DetailFromDb.AccountId = detail.AccountId;
            DetailFromDb.DepartmentId = detail.DepartmentId;
            DetailFromDb.ServiceId = detail.ServiceId;
            DetailFromDb.Amount = detail.Amount;
            DetailFromDb.PaymentDate = detail.PaymentDate;
            DetailFromDb.ApplicationUserId = detail.ApplicationUserId;
            DetailFromDb.EmployeeId = detail.EmployeeId;
            DetailFromDb.Notes = detail.Notes;
            DetailFromDb.Paid = detail.Paid;
            _db.SaveChanges();
        }
    }
}

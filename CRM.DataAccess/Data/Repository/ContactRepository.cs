using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DataAccess.Data.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly ApplicationDbContext _db;
        public ContactRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(Contact contact)
        {
            var contactFromDb = _db.Contact.FirstOrDefault(m => m.Id == contact.Id);

            contactFromDb.Name = contact.Name;
            contactFromDb.AccountId = contact.AccountId;
            contactFromDb.Email = contact.Email;
            contactFromDb.Phone = contact.Phone;
            contactFromDb.Position = contact.Position;
            contactFromDb.Description = contact.Description;

            _db.SaveChanges();
        }
    }
}

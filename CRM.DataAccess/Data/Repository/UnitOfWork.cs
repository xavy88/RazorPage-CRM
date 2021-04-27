using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Data.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Department = new DepartmentRepository(_db);
            Service = new ServiceRepository(_db);
            Position = new PositionRepository(_db);
            Employee = new EmployeeRepository(_db);
            Account = new AccountRepository(_db);
            Contact = new ContactRepository(_db);
            Task = new TaskRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            TaskAssignment = new TaskAssignmentRepository(_db);
            Order = new OrderRepository(_db);
            Detail = new DetailRepository(_db);

        }
        public IDepartmentRepository Department { get; private set; }
        public IServiceRepository Service { get; private set; }
        public IPositionRepository Position { get; private set; }
        public IEmployeeRepository Employee { get; private set; }
        public IAccountRepository Account { get; private set; }
        public IContactRepository Contact { get; private set; }
        public ITaskRepository Task { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ITaskAssignmentRepository TaskAssignment { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IDetailRepository Detail { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

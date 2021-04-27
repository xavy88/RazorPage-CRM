using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IDepartmentRepository Department { get; }
        IServiceRepository Service { get; }
        IPositionRepository Position { get; }
        IEmployeeRepository Employee { get; }
        IAccountRepository Account { get; }
        IContactRepository Contact { get; }
        ITaskRepository Task { get; }
        IApplicationUserRepository ApplicationUser { get; }
        ITaskAssignmentRepository TaskAssignment { get; }
        IOrderRepository Order { get; }
        IDetailRepository Detail { get; }
        void Save();

    }
}

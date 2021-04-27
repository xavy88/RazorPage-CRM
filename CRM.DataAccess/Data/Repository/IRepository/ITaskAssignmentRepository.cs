using CRM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Data.Repository.IRepository
{
    public interface ITaskAssignmentRepository : IRepository<TaskAssignment>
    {
        void Update(TaskAssignment taskAssigment);
        void Completed(TaskAssignment taskAssigment);

    }
}

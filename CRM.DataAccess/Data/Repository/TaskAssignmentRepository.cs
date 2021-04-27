using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DataAccess.Data.Repository
{
    public class TaskAssignmentRepository : Repository<TaskAssignment>, ITaskAssignmentRepository
    {
        private readonly ApplicationDbContext _db;

        public TaskAssignmentRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Completed(TaskAssignment taskAssignment)
        {
            var taskAssignmentFromDb = _db.TaskAssignment.FirstOrDefault(m => m.Id == taskAssignment.Id);

             taskAssignmentFromDb.Completed = true;
            _db.SaveChanges();
        }

        public void Update(TaskAssignment taskAssignment)
        {
            var taskAssignmentFromDb = _db.TaskAssignment.FirstOrDefault(m => m.Id == taskAssignment.Id);

            taskAssignmentFromDb.AccountId = taskAssignment.AccountId;
            taskAssignmentFromDb.TaskId = taskAssignment.TaskId;
            taskAssignmentFromDb.StartDate = DateTime.Now;
            taskAssignmentFromDb.DueDate = taskAssignment.DueDate;
            taskAssignmentFromDb.ApplicationUserId = taskAssignment.ApplicationUserId;
            taskAssignmentFromDb.DepartmentId = taskAssignment.DepartmentId;
            taskAssignmentFromDb.Notes = taskAssignment.Notes;
            taskAssignmentFromDb.Completed = taskAssignment.Completed;
            _db.SaveChanges();
        }
    }
}

using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DataAccess.Data.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        private readonly ApplicationDbContext _db;

        public TaskRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetTaskListForDropDown()
        {
            return _db.Task.Where(i => i.Status == false).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Disable(Task task)
        {
            var taskFromDb = _db.Task.FirstOrDefault(m => m.Id == task.Id);

            taskFromDb.Status = true;

            _db.SaveChanges();
        }
        public void Update(Task task)
        {
            var taskFromDb = _db.Task.FirstOrDefault(m => m.Id == task.Id);

            taskFromDb.Name = task.Name;
            taskFromDb.Duration = task.Duration;
            taskFromDb.Description = task.Description;
            taskFromDb.PositionId = task.PositionId;
            taskFromDb.DepartmentId = task.DepartmentId;
            taskFromDb.Status = task.Status;

            _db.SaveChanges();
            
          


        }
    }
}

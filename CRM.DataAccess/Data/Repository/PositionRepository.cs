using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DataAccess.Data.Repository
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        private readonly ApplicationDbContext _db;
        public PositionRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetPositionListForDropDown()
        {
            return _db.Position.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }
        public void Update(Position position)
        {
            var positionFromDb = _db.Position.FirstOrDefault(m => m.Id == position.Id);

            positionFromDb.Name = position.Name;
            positionFromDb.DepartmentId = position.DepartmentId;
            positionFromDb.Description = position.Description;
           
            _db.SaveChanges();
        }
    }
}

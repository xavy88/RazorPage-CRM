using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles =SD.ManagerRole + "," +  SD.RootRole)]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _uniOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _uniOfWork.Department.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _uniOfWork.Department.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb==null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _uniOfWork.Department.Remove(objFromDb);
            _uniOfWork.Save();
            return Json(new { success = true, message = "Delete successfuly" });
        }
    }
}

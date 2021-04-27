using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController : Controller
    {
        private readonly IUnitOfWork _uniOfWork;
        
        public TaskAssignmentController(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            if (User.IsInRole(SD.EmployeeRole))
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                return Json(new { data = _uniOfWork.TaskAssignment.GetAll(null, q => (IOrderedQueryable<Models.TaskAssignment>)q.Where(c => c.ApplicationUserId == claim.Value && c.Completed == false), "Department,Account,Task,ApplicationUser") });
            }
            else
            {
                return Json(new { data = _uniOfWork.TaskAssignment.GetAll(null, q => (IOrderedQueryable<Models.TaskAssignment>)q.Where(c => c.Completed == false), "Department,Account,Task,ApplicationUser") });
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _uniOfWork.TaskAssignment.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _uniOfWork.TaskAssignment.Remove(objFromDb);
            _uniOfWork.Save();
            return Json(new { success = true, message = "Delete successfuly" });
        }
    }
}

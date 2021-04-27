using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly IUnitOfWork _uniOfWork;
       
        public TaskController(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _uniOfWork.Task.GetAll(null, q => (IOrderedQueryable<Models.Task>)q.Where(c => c.Status == false), "Department,Position") });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var objFromDb = _uniOfWork.Task.GetFirstOrDefault(u => u.Id == id);
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Error while deleting" });
                }

                _uniOfWork.Task.Remove(objFromDb);
                _uniOfWork.Save();
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = "Error while deleting" });
            }
           
            return Json(new { success = true, message = "Delete successfuly" });
        }
    }
}

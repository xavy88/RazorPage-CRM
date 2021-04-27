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
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _uniOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EmployeeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _uniOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _uniOfWork.Employee.GetAll(null, q => (IOrderedQueryable<Models.Employee>)q.Where(c => c.Status == false), "Department,Position") });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var objFromDb = _uniOfWork.Employee.GetFirstOrDefault(u => u.Id == id);
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Error while deleting" });
                }

                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                _uniOfWork.Employee.Remove(objFromDb);
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

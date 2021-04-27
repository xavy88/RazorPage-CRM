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
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _uniOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AccountController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _uniOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _uniOfWork.Account.GetAll(null, q => (IOrderedQueryable<Models.Account>)q.Where(c => c.Status == false)) });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var objFromDb = _uniOfWork.Account.GetFirstOrDefault(u => u.Id == id);
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Error while deleting" });
                }

                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                _uniOfWork.Account.Remove(objFromDb);
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

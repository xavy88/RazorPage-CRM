using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : Controller
    {
        private readonly IUnitOfWork _uniOfWork;
        
        public DetailController(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            
        }
       [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _uniOfWork.Detail.GetAll(null, /*q => (IOrderedQueryable<Models.Detail>)q.Where(c => c.Paid==false)*/null, "Order,Account,Department,Service,ApplicationUser,Employee") });
        }

        [HttpGet("details")]
        public IActionResult Details(int id)
        {
            return Json(new { data = _uniOfWork.Detail.GetAll(null, q => (IOrderedQueryable<Models.Detail>)q.Where(c => c.OrderId == id), "Order,Account,Department,Service,ApplicationUser,Employee") });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _uniOfWork.Detail.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _uniOfWork.Detail.Remove(objFromDb);
            _uniOfWork.Save();
            return Json(new { success = true, message = "Delete successfuly" });
        }
    }
}

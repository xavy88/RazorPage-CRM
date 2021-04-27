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
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _uniOfWork;
        
        public OrderController(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            
        }
        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _uniOfWork.Order.GetAll(null, q => (IOrderedQueryable<Models.Order>)q.Where(c => c.Closed==false), null) });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _uniOfWork.Order.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _uniOfWork.Order.Remove(objFromDb);
            _uniOfWork.Save();
            return Json(new { success = true, message = "Delete successfuly" });
        }
    }
}

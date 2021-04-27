using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _uniOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _uniOfWork.Contact.GetAll(null, null, "Account") });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _uniOfWork.Contact.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb==null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _uniOfWork.Contact.Remove(objFromDb);
            _uniOfWork.Save();
            return Json(new { success = true, message = "Delete successfuly" });
        }
    }
}

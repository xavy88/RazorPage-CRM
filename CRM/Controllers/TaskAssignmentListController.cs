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
    public class TaskAssignmentListController : Controller
    {
        private readonly IUnitOfWork _uniOfWork;
        
        public TaskAssignmentListController(IUnitOfWork unitOfWork)
        {
            _uniOfWork = unitOfWork;
            
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get(string deptName = null)
        {
            if (deptName=="SEO")
            {
                return Json(new { data = _uniOfWork.TaskAssignment.GetAll(null, q => (IOrderedQueryable<Models.TaskAssignment>)q.Where(c => c.Department.Name == "SEO"), "Department,Account,Task,ApplicationUser") });
            }
            else
            {
                if (deptName == "PPC")
                {
                    return Json(new { data = _uniOfWork.TaskAssignment.GetAll(null, q => (IOrderedQueryable<Models.TaskAssignment>)q.Where(c => c.Department.Name == "PPC"), "Department,Account,Task,ApplicationUser") });
                }
                else
                {
                    if (deptName == "APP")
                    {
                        return Json(new { data = _uniOfWork.TaskAssignment.GetAll(null, q => (IOrderedQueryable<Models.TaskAssignment>)q.Where(c => c.Department.Name == "APP"), "Department,Account,Task,ApplicationUser") });
                    }
                    else
                    {
                        if (deptName == "SALES")
                        {
                            return Json(new { data = _uniOfWork.TaskAssignment.GetAll(null, q => (IOrderedQueryable<Models.TaskAssignment>)q.Where(c => c.Department.Name == "SALES"), "Department,Account,Task,ApplicationUser") });
                        }
                        else
                        {
                            if (deptName == "WEB")
                            {
                                return Json(new { data = _uniOfWork.TaskAssignment.GetAll(null, q => (IOrderedQueryable<Models.TaskAssignment>)q.Where(c => c.Department.Name == "WEB"), "Department,Account,Task,ApplicationUser") });
                            }
                            else
                            {
                                if (deptName == "SM")
                                {
                                    return Json(new { data = _uniOfWork.TaskAssignment.GetAll(null, q => (IOrderedQueryable<Models.TaskAssignment>)q.Where(c => c.Department.Name == "SM"), "Department,Account,Task,ApplicationUser") });
                                }
                                else
                                {
                                    return Json(new { data = _uniOfWork.TaskAssignment.GetAll(null, null, "Department,Account,Task,ApplicationUser") });
                                }
                            }
                        }
                    }

                }
            }
            
        }
       
    }
}

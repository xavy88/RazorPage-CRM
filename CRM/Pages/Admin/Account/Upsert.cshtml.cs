using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CRM.DataAccess.Data.Repository.IRepository;
using CRM.Models;
using CRM.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRM.Pages.Admin.Account
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostEnvironment;
        }
        //Using the below code is not necessary to declare into de Post method
        [BindProperty]
        public Models.Account AccountObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            AccountObj = new Models.Account();
        
            if (id!=null)
            {
                AccountObj = _unitOfWork.Account.GetFirstOrDefault(u => u.Id == id);
                if (AccountObj==null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost(/*Models.Department DeparmentObj*/)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (AccountObj.Id==0)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\accounts");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream= new FileStream(Path.Combine(uploads,fileName+extension),FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                AccountObj.Image = @"\images\accounts\" + fileName + extension;

                _unitOfWork.Account.Add(AccountObj);


            }
            else
            {

                //Edit an Account
                var objFromDb = _unitOfWork.Account.Get(AccountObj.Id);
                if (files.Count>0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\accounts");
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    AccountObj.Image = @"\images\accounts\" + fileName + extension;
                    //_unitOfWork.Employee.Add(EmployeeObj.Employee);
                }
                else
                {
                    AccountObj.Image = objFromDb.Image;
                }


                _unitOfWork.Account.Update(AccountObj);
            } 

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

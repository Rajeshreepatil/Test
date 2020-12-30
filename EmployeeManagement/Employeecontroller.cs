using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement
{

    public class Employeecontroller : Controller
    {
        
        EmployeeDBAccessLayer empdb = new EmployeeDBAccessLayer();
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind] EmployeeEntities employeeEntities)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = empdb.AddEmployeeRecord(employeeEntities);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
    }
}
       
  
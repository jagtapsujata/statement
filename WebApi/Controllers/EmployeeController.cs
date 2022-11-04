using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc.Razor;
using System.Web.UI.WebControls;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        Employee2Entities db=new Employee2Entities();

        [HttpGet]
        public IHttpActionResult GetEmployee()
        {
            List<Employee2> list = db.Employee2.ToList();
            return Ok(list);
            
               
        }
        [HttpPost]
        public IHttpActionResult EmpInsert(Employee2 e)
        {
            db.Employee2.Add(e);
            db.SaveChanges();
            return Ok();

        }
  










        /*public string[] Employees = { "Sujata", "Vaishnavi" };
        [HttpGet]
        public string[] GetEmployee()
        {
            return Employees;
        }
        [HttpGet]
        public string GetEmployeeByIndex(int id)

        {
            return Employees[id];
        }*/
       
    }
}






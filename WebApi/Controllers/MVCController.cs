using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MVCController : Controller
    {
        // GET: MVC
        HttpClient Client=new HttpClient();

        public ActionResult Index()
        {
            List<Employee2> emp_list = new List<Employee2>();
            Client.BaseAddress = new Uri("https://localhost:44392/api/Employee");
            var response = Client.GetAsync("Employee");
            response.Wait();
            var test=response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync< List < Employee2 >>();
                display.Wait();
               
                emp_list = display.Result; 

            }

            return View(emp_list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee2 emp)
        {
            Client.BaseAddress = new Uri("https://localhost:44392/api/Employee");
            var response = Client.PostAsJsonAsync<Employee2>("Employee",emp);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View("Create");

        }
    }
}
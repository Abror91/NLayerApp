using NTierDemo.BLL.DTOs;
using NTierDemo.BLL.Interfaces;
using NTierDemo.GUI.Models.EmployeeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NTierDemo.GUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employees;
        public HomeController()
        {

        }
        public HomeController(IEmployeeService employees)
        {
            _employees = employees;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetEmployees()
        {
            return View(_employees.Get());
        }

        public ActionResult GetById(int id)
        {
            var employee = _employees.GetById(id);
            return View(employee);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                var employeeToSave = new EmployeeDTO()
                {
                    Name = employee.Name,
                    Age = employee.Age,
                    HiredDate = employee.HiredDate,
                    GrossSalary = employee.GrossSalary
                };
                _employees.Add(employeeToSave);
            }
            ModelState.AddModelError("", "Unable to save employee. Please try again later.");
            return View(employee);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
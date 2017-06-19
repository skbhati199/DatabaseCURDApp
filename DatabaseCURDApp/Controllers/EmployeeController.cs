using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer;

namespace DatabaseCURDApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            BusinessDbLayer employeeBusinessLayer = new BusinessDbLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }


        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BusinessDbLayer employeeBusinessLayer = new BusinessDbLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.ID == id);
            return View(employee);

        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            BusinessDbLayer employeeBusinessLayer = new BusinessDbLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(x => x.ID == id);
            UpdateModel<IEmployee>(employee);
            if (ModelState.IsValid)
            {
              
                employeeBusinessLayer.SaveEmmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {

            Employee employee = new Employee();
            TryUpdateModel(employee);

            if (ModelState.IsValid)
            {
                BusinessDbLayer employeeBusinessLayer = new BusinessDbLayer();
                employeeBusinessLayer.AddEmmployee(employee);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            BusinessDbLayer employeeBusinessLayer = new BusinessDbLayer();
            employeeBusinessLayer.DeleteEmployee(id);


            return RedirectToAction("Index");
        }
    }
}
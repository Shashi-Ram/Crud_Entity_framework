using CrudP1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudP1.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public IActionResult Index()
        {
            List<Employee> emp = dbContext.Employees.ToList();
            return View(emp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Employee emp)
        {
            dbContext.Employees.Add(emp);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            if (emp != null)
            {
                dbContext.Employees.Remove(emp);
                dbContext.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return View(emp);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            dbContext.Employees.Update(employee);
            dbContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

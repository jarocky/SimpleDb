using System;
using System.Linq;
using System.Web.Mvc;
using SimpleDb.DataAccess;
using SimpleDb.DataAccess.Enities;
using SimpleDb.Models;

namespace SimpleDb.Controllers
{
  public class EmployeeController : Controller
  {
    [HttpGet]
    public ActionResult Add(EmployeeModel employeeModel)
    {
      employeeModel = employeeModel ?? new EmployeeModel();

      return View(employeeModel);
    }

    [HttpPost]
    public ActionResult Adding(EmployeeModel employeeModel)
    {
      if (!ModelState.IsValid)
      {
        return Add(employeeModel);
      }

      var employee = new Employee
      {
        Identifier = Guid.NewGuid(),
        FirstName = employeeModel.FirstName,
        LastName = employeeModel.LastName
      };

      using (var ctx = new ResuestServiceContext())
      {
        ctx.Employees.Add(employee);
        ctx.SaveChanges();
      }

      return RedirectToAction("Index", "Employees");
    }

    [HttpGet]
    public ActionResult Edit(Guid identifier)
    {
      Employee employee = null;
      using (var ctx = new ResuestServiceContext())
      {
        employee = ctx.Employees.SingleOrDefault(x => x.Identifier == identifier);
      }

      var employeeModel = new EmployeeModel
      {
        Identifier = employee.Identifier,
        FirstName = employee.FirstName,
        LastName = employee.LastName
      };

      return View(employeeModel);
    }

    [HttpPost]
    public ActionResult Edit(EmployeeModel employeeModel)
    {
      if (employeeModel == null)
      {
        return RedirectToAction("Index", "Employees");
      }

      return View(employeeModel);
    }

    [HttpPost]
    public ActionResult Editing(EmployeeModel employeeModel)
    {
      if (!ModelState.IsValid)
      {
        return Edit(employeeModel);
      }

      using (var ctx = new ResuestServiceContext())
      {
        var employee = ctx.Employees.SingleOrDefault(x => x.Identifier == employeeModel.Identifier);
        employee.FirstName = employeeModel.FirstName;
        employee.LastName = employeeModel.LastName;
        ctx.SaveChanges();
      }

      return RedirectToAction("Index", "Employees");
    }
  }
}
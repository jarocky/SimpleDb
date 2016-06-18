using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SimpleDb.DataAccess;
using SimpleDb.Models;

namespace SimpleDb.Controllers
{
  public class EmployeesController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      List<EmployeeModel> employees = null;
      using (var ctx = new ResuestServiceContext())
      {
        employees = ctx.Employees.Select(x => new EmployeeModel
        {
          Identifier = x.Identifier,
          FirstName = x.FirstName,
          LastName = x.LastName
        }).ToList();
      }

      return View(employees);
    }
  }
}
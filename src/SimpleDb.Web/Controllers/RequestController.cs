using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SimpleDb.DataAccess;
using SimpleDb.DataAccess.Enities;
using SimpleDb.Models;

namespace SimpleDb.Controllers
{
  public class RequestController : Controller
  {
    [HttpGet]
    public ActionResult Add(string clientSymbol)
    {
      var requestModel = new RequestAddModel
      {
        ClientSymbol = clientSymbol
      };

      return View(requestModel);
    }

    [HttpPost]
    public ActionResult Adding(RequestAddModel requestModel)
    {
      var request = new Request
      {
        Id = Guid.NewGuid(),
        ClientSymbol = requestModel.ClientSymbol,
        Description = requestModel.Description,
        RequestPriority = requestModel.RequestPriority,
        RequestType = requestModel.RequestType,
        RequestStatus = RequestStatus.Nowy,
        Date = DateTime.Now,
      };

      using (var ctx = new ResuestServiceContext())
      {
        ctx.Requests.Add(request);
        ctx.SaveChanges();
      }

      return RedirectToAction("Index", "Requests");
    }

    [HttpGet]
    public ActionResult Closing(Guid id)
    {
      using (var ctx = new ResuestServiceContext())
      {
        var request = ctx.Requests.SingleOrDefault(r => r.Id == id);
        request.RequestStatus = RequestStatus.Zamkniety;
        request.ResolveDate = DateTime.Now;
        ctx.SaveChanges();
      }

      return RedirectToAction("Index", "Requests");
    }

    [HttpGet]
    public ActionResult Assign(Guid id)
    {
      List<Employee> employees = null;
      using (var ctx = new ResuestServiceContext())
      {
        employees = ctx.Employees.ToList();
      }

      var requestEmployees = new RequestEmployeesModel
      {
        RequestId = id,
        Employees = employees.ToList().Select(e => new EmployeeModel
        {
          Identifier = e.Identifier,
          FirstName = e.FirstName,
          LastName = e.LastName
        }).ToList()
      };

      return View(requestEmployees);
    }

    [HttpPost]
    public ActionResult Assigning(RequestEmployeesModel requestEmployeesModel)
    {
      using (var ctx = new ResuestServiceContext())
      {
        var employeesToRemove = ctx.EmployeeRequests.Where(e => e.RequestId == requestEmployeesModel.RequestId).AsEnumerable();
        ctx.EmployeeRequests.RemoveRange(employeesToRemove);
        var employeeRequests = requestEmployeesModel.Employees.Where(e => e.IsAssigned).Select(e => new EmployeeRequest
        {
          RequestId = requestEmployeesModel.RequestId,
          EmployeeIdentifier = e.Identifier
        });
        ctx.EmployeeRequests.AddRange(employeeRequests);
        ctx.SaveChanges();
      }

      return RedirectToAction("Index", "Requests");
    }

    [HttpGet]
    public ActionResult Preview(Guid id)
    {
      RequestPreviewModel request = null;
      using (var ctx = new ResuestServiceContext())
      {
        request = ctx.Requests
          .Join(ctx.Clients, r => r.ClientSymbol, c => c.Symbol, (r, c) => new RequestPreviewModel
          {
            Id = r.Id,
            ClientSymbol = c.Symbol,
            RequestPriority = r.RequestPriority,
            RequestType = r.RequestType,
            Description = r.Description
          }).SingleOrDefault(r => r.Id == id);
        request.Employees = ctx.EmployeeRequests
          .Join(ctx.Employees, er => er.EmployeeIdentifier, r => r.Identifier, (er, r) => new
          {
            RequestId = er.RequestId,
            Identifier = r.Identifier,
            FirstName = r.FirstName,
            LastName = r.LastName
          }).Where(er => er.RequestId == id).Select(er => new EmployeeModel
          {
            Identifier = er.Identifier,
            FirstName = er.FirstName,
            LastName = er.LastName
          }).ToList();
      }

      return View(request);
    }
  }
}
using System;
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
      var requestModel = new RequestAdd
      {
        ClientSymbol = clientSymbol
      };

      return View(requestModel);
    }

    [HttpPost]
    public ActionResult Adding(RequestAdd requestModel)
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
  }
}
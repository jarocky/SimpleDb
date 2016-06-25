using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SimpleDb.DataAccess;
using SimpleDb.Models;

namespace SimpleDb.Controllers
{
  public class RequestsController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      List<RequestForListModel> requests = null;
      using (var ctx = new ResuestServiceContext())
      {
        requests = ctx.Requests
          .Join(ctx.Clients, r => r.ClientSymbol, c => c.Symbol, (r, c) => new RequestForListModel
          {
            Identifier = r.Id,
            ClientName = c.Name,
            Date = r.Date,
            RequestPriority = r.RequestPriority,
            RequestType = r.RequestType,
            RequestStatus = r.RequestStatus,
            ResolveDate = r.ResolveDate
          }).ToList();
      }

      return View(requests);
    }
  }
}
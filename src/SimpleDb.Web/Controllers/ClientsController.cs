using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SimpleDb.DataAccess;
using SimpleDb.DataAccess.Enities;
using SimpleDb.Models;

namespace SimpleDb.Controllers
{
  public class ClientsController : Controller
  {
    // GET: Clients
    public ActionResult Index()
    {
      List<Client> clients = null;
      List<ClientAddress> addresses = null;
      using (var ctx = new ResuestServiceContext())
      {
        clients = ctx.Clients.ToList();
        addresses = ctx.ClientAddresses.ToList();
      }

      var clientsWithAddresQuery = from c in clients
        join a in addresses on c.Symbol equals a.ClientSymbol
        select new ClientWithAddress
        {
          Symbol = c.Symbol,
          Name = c.Name,
          Email = c.Email,
          PhoneNumber = c.PhoneNumber,
          Description = c.Description,
          Street = a.Street,
          Number = a.Number,
          ZipCode = a.ZipCode,
          City = a.City
  };

      var clientsWithAddres = clientsWithAddresQuery.ToList();

      return View(clientsWithAddres);
    }
  }
}
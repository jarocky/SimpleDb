using System.Linq;
using System.Web.Mvc;
using SimpleDb.DataAccess;
using SimpleDb.DataAccess.Enities;
using SimpleDb.Models;

namespace SimpleDb.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet]
    public ActionResult Add()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Adding(ClientWithAddress clientWithAddres)
    {
      var client = new Client
      {
        Symbol = clientWithAddres.Symbol,
        Name = clientWithAddres.Name,
        Email = clientWithAddres.Email,
        PhoneNumber = clientWithAddres.PhoneNumber,
        Description = clientWithAddres.Description
      };

      var clientAddress = new ClientAddress
      {
        ClientSymbol = clientWithAddres.Symbol,
        Street = clientWithAddres.Street,
        Number = clientWithAddres.Number,
        ZipCode = clientWithAddres.ZipCode,
        City = clientWithAddres.City
      };

      using (var ctx = new ResuestServiceContext())
      {
        ctx.Clients.Add(client);
        ctx.ClientAddresses.Add(clientAddress);
        ctx.SaveChanges();
      }

      return RedirectToAction("Index", "Clients");
    }


    [HttpGet]
    public ActionResult Edit(string symbol)
    {
      Client client = null;
      ClientAddress address = null;
      using (var ctx = new ResuestServiceContext())
      {
        client = ctx.Clients.SingleOrDefault(x => x.Symbol == symbol);
        address = ctx.ClientAddresses.SingleOrDefault(x => x.ClientSymbol == symbol);
      }

      var clientWithAddress = new ClientWithAddress
      {
        Symbol = client.Symbol,
        Name = client.Name,
        Email = client.Email,
        PhoneNumber = client.PhoneNumber,
        Description = client.Description,
        Street = address.Street,
        Number = address.Number,
        ZipCode = address.ZipCode,
        City = address.City
      };

      return View(clientWithAddress);
    }

    [HttpPost]
    public ActionResult Editing(ClientWithAddress clientWithAddres)
    {
      using (var ctx = new ResuestServiceContext())
      {
        var client = ctx.Clients.SingleOrDefault(x => x.Symbol == clientWithAddres.Symbol);
        var address = ctx.ClientAddresses.SingleOrDefault(x => x.ClientSymbol == clientWithAddres.Symbol);
        client.Name = clientWithAddres.Name;
        client.Email = clientWithAddres.Email;
        client.PhoneNumber = clientWithAddres.PhoneNumber;
        client.Description = clientWithAddres.Description;
        address.Street = clientWithAddres.Street;
        address.Number = clientWithAddres.Number;
        address.ZipCode = clientWithAddres.ZipCode;
        address.City = clientWithAddres.City;
        ctx.SaveChanges();
      }

      return RedirectToAction("Index", "Clients");
    }
  }
}
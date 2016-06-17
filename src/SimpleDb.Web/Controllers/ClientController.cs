using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleDb.Controllers
{
  public class ClientController : Controller
  {
    // GET: Client
    public ActionResult Add()
    {
      return View();
    }

    public ActionResult Edit(string symbol)
    {
      return View();
    }
  }
}
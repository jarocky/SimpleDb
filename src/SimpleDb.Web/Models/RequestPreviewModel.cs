using System;
using System.Collections.Generic;
using System.ComponentModel;
using SimpleDb.DataAccess.Enities;

namespace SimpleDb.Models
{
  public class RequestPreviewModel
  {
    public RequestPreviewModel()
    {
      Employees = new List<EmployeeModel>();
    }

    public Guid Id { get; set; }

    [DisplayName("Symbol Klienta")]
    public string ClientSymbol { get; set; }

    [DisplayName("Priorytet")]
    public RequestPriority RequestPriority { get; set; }

    [DisplayName("Rodzaj")]
    public RequestType RequestType { get; set; }

    [DisplayName("Opis zgłoszenia")]
    public string Description { get; set; }
    
    public List<EmployeeModel> Employees { get; set; }
  }
}
using System;
using System.ComponentModel;

namespace SimpleDb.Models
{
  public class EmployeeModel
  {
    [DisplayName("Identyfikator")]
    public Guid Identifier { get; set; }

    [DisplayName("Imię")]
    public string FirstName { get; set; }

    [DisplayName("Nazwisko")]
    public string LastName { get; set; }
  }
}
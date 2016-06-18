using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleDb.DataAccess.Enities
{
  public class Employee
  {
    [Key]
    public Guid Identifier { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
  }
}
using System;

namespace SimpleDb.Models
{
  public class EmployeeModel
  {
    public Guid Identifier { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }
  }
}
using System;
using System.Collections.Generic;

namespace SimpleDb.Models
{
  public class RequestEmployeesModel
  {
    public RequestEmployeesModel()
    {
      Employees = new List<EmployeeModel>();
    }

    public Guid RequestId { get; set; }

    public List<EmployeeModel> Employees { get; set; }
  }
}
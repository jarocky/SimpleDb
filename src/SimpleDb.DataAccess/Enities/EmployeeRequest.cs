using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleDb.DataAccess.Enities
{
  public class EmployeeRequest
  {
    [Key]
    [Column(Order = 1)]
    public Guid RequestId { get; set; }

    [Key]
    [Column(Order = 2)]
    public Guid EmployeeIdentifier { get; set; }
  }
}
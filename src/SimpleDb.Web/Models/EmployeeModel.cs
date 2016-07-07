using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleDb.Models
{
  public class EmployeeModel
  {
    [DisplayName("Identyfikator")]
    public Guid Identifier { get; set; }

    [DisplayName("Imię")]
    [Required]
    [StringLength(64, MinimumLength = 3)]
    public string FirstName { get; set; }

    [DisplayName("Nazwisko")]
    [Required]
    [StringLength(64, MinimumLength = 3)]
    public string LastName { get; set; }

    public bool IsAssigned { get; set; }
  }
}
using System.ComponentModel;
using SimpleDb.DataAccess.Enities;

namespace SimpleDb.Models
{
  public class ClientWithAddressModel
  {
    [DisplayName("Symbol")]
    public string Symbol { get; set; }

    [DisplayName("Nazwa")]
    public string Name { get; set; }

    [DisplayName("Email")]
    public string Email { get; set; }

    [DisplayName("Numer telefonu")]
    public string PhoneNumber { get; set; }

    [DisplayName("Opis")]
    public string Description { get; set; }

    [DisplayName("Ulica")]
    public string Street { get; set; }

    [DisplayName("Numer")]
    public string Number { get; set; }

    [DisplayName("Kod pocztowy")]
    public string ZipCode { get; set; }

    [DisplayName("Miasto")]
    public string City { get; set; }
  }
}
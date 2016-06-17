using SimpleDb.DataAccess.Enities;

namespace SimpleDb.Models
{
  public class ClientWithAddress
  {
    public string Symbol { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Description { get; set; }

    public string Street { get; set; }

    public string Number { get; set; }

    public string ZipCode { get; set; }

    public string City { get; set; }
  }
}
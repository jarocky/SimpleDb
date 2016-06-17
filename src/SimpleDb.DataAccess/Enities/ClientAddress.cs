using System.ComponentModel.DataAnnotations;

namespace SimpleDb.DataAccess.Enities
{
  public class ClientAddress
  {
    [Key]
    public string ClientSymbol { get; set; }

    public string Street { get; set; }

    public string Number { get; set; }

    public string ZipCode { get; set; }

    public string City { get; set; }
  }
}
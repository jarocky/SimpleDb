using System.ComponentModel.DataAnnotations;

namespace SimpleDb.DataAccess.Enities
{
  public class Client
  {
    [Key]
    public string Symbol { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Description { get; set; }
  }
}
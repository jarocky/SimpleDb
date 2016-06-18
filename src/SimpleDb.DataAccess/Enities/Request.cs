using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleDb.DataAccess.Enities
{
  public class Request
  {
    [Key]
    public Guid Id { get; set; }

    public string ClientSymbol { get; set; }

    public string Description { get; set; }

    [Column("RequestStatusId")]
    public RequestStatus RequestStatus { get; set; }

    public DateTime Date { get; set; }

    public DateTime ResolveDate { get; set; }

    public string ResolveDescription { get; set; }

    [Column("RequestPriorityId")]
    public RequestPriority RequestPriority { get; set; }

    [Column("RequestTypeId")]
    public RequestType RequestType { get; set; }
  }
}
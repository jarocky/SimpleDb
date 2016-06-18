using System;
using SimpleDb.DataAccess.Enities;

namespace SimpleDb.Models
{
  public class RequestForList
  {
    public Guid Identifier { get; set; }

    public string ClientName { get; set; }

    public DateTime Date { get; set; }

    public RequestPriority RequestPriority { get; set; }

    public RequestType RequestType { get; set; }

    public RequestStatus RequestStatus { get; set; }

    public DateTime? ResolveDate { get; set; }
  }
}
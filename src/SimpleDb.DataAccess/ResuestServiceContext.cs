using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SimpleDb.DataAccess.Enities;

namespace SimpleDb.DataAccess
{
  public class ResuestServiceContext : DbContext
  {
    public ResuestServiceContext() : base("name=RequestServiceDatabase")
    {
    }

    public DbSet<Client> Clients { get; set; }

    public DbSet<ClientAddress> ClientAddresses { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Request> Requests { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
  }
}
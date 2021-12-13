using Microsoft.EntityFrameworkCore;
using UaConnects.Domain.Entities;

namespace UaConnects.Infrastructure.DataAccess
{
    public class UaConnectsContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UaConnectsContext(DbContextOptions<UaConnectsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

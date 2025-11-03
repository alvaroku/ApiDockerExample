using Microsoft.EntityFrameworkCore;

namespace ApiDockerExample
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }  
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}

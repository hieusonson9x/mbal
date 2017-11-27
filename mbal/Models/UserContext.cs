using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Agency> agencies { get; set; }
        public DbSet<Insurrance> insurrances { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Compensation> compensations { get; set; }
        public DbSet<Payment> payments { get; set; }

    }
}

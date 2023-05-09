using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TieredWebAPI.Models;

namespace TieredWebAPI.Data
{
    public class TieredWebAPIContext : DbContext
    {
        public TieredWebAPIContext (DbContextOptions<TieredWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<TieredWebAPI.Models.BankAccount> BankAccount { get; set; } = default!;
        public DbSet<Customer> Customer { get; set; } = default!;
    }
}

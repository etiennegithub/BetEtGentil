using BetEtMechant.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetEtMechant.Data
{
    public class BetDbContext : IdentityDbContext<User>
    {
        public BetDbContext(DbContextOptions<BetDbContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Championship> Championships { get; set; }

    }
}

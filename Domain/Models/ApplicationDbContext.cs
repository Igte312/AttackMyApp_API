using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region tables
        public DbSet<Users> Users { get; set; }
        public DbSet<Siegfried> Siegfried { get; set; }
        public DbSet<UserType> UserType { get; set; }
        #endregion tables

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}

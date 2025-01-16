using Microsoft.EntityFrameworkCore;
using NetChallange.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Infrastructure.Data;

public class ApplicationDbContext:DbContext
{
    public DbSet<Carriers> Carriers { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<CarrierConfigurations> CarrierConfigurations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-BN6OF03\\SQLEXPRESS; database=NetChallangeDB; integrated security=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Carriers>()
            .HasOne(c => c.CarrierConfigurations)
            .WithOne(cc => cc.Carrier)
            .HasForeignKey<Carriers>(c => c.CarrierConfigurationId);

        
        modelBuilder.Entity<Orders>()
            .HasOne(o => o.Carriers)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CarrierId);

      
    }
}

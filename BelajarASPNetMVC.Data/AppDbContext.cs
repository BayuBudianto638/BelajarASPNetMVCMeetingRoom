using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelajarASPNetMVC.Data.Databases;

namespace BelajarASPNetMVC.Data
{
    public class AppDbContext : DbContext
    {
        // DbSet Here
        public DbSet<Company> Company { get; set; }
        public DbSet<Beverage> Beverage { get; set; }
        public DbSet<Layout> Layout { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomSlot> RoomSlot { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}

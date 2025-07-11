using Microsoft.EntityFrameworkCore;
using EquipmentInventory.Models;

namespace EquipmentInventory.Data
{
    public class DeviceDbContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        private readonly string _dbPath;

        public DeviceDbContext()
        {
            _dbPath = "devices.db"; 
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }
    }
}

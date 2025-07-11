using System.Collections.Generic;
using System.Linq;
using EquipmentInventory.Models;

namespace EquipmentInventory.Data
{
    // Класс для работы с бд ,чтобы разорать жесткую связку между ViewModel
    public class DeviceRepository : IDeviceRepository
    {
        public List<Device> GetAllDevices()
        {
            using var db = new DeviceDbContext();
            return db.Devices.ToList();
        }

        public void AddDevice(Device device)
        {
            using var db = new DeviceDbContext();
            db.Devices.Add(device);
            db.SaveChanges();
        }

        public void UpdateDevice(Device device)
        {
            using var db = new DeviceDbContext();
            var existing = db.Devices.Find(device.Id);
            if (existing != null)
            {
                existing.Name = device.Name;
                existing.Type = device.Type;
                existing.Status = device.Status;
                db.SaveChanges();
            }
        }

        public void DeleteDevice(Device device)
        {
            using var db = new DeviceDbContext();
            var existing = db.Devices.Find(device.Id);
            if (existing != null)
            {
                db.Devices.Remove(existing);
                db.SaveChanges();
            }
        }
    }
}

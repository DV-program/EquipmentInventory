using System.Collections.Generic;
using EquipmentInventory.Models;

namespace EquipmentInventory.Data
{
    public interface IDeviceRepository
    {
        List<Device> GetAllDevices();
        void AddDevice(Device device);
        void UpdateDevice(Device device);
        void DeleteDevice(Device device);
    }
}

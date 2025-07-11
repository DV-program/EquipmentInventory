using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentInventory.Models
{
    // Класс Model
    public class Device
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DeviceType Type { get; set; }
        public DeviceStatus Status { get; set; }
    }
    public enum DeviceType
    {
        Printer,
        Scanner,
        Monitor
    }

    public enum DeviceStatus
    {
        InUse,
        InStorage,
        UnderRepair
    }

}

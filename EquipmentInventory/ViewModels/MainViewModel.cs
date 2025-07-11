using EquipmentInventory.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EquipmentInventory.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace EquipmentInventory.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IDeviceRepository _repository;

        [ObservableProperty] private string name;
        [ObservableProperty] private DeviceType selectedType;
        [ObservableProperty] private DeviceStatus selectedStatus;

        public ObservableCollection<Device> Devices { get; } = new();

        public IEnumerable<DeviceType> DeviceTypes 
            => Enum.GetValues(typeof(DeviceType)).Cast<DeviceType>();
        public IEnumerable<DeviceStatus> DeviceStatuses 
            => Enum.GetValues(typeof(DeviceStatus)).Cast<DeviceStatus>();

        public MainViewModel()
        {
            _repository = new DeviceRepository();

            LoadDevicesFromDb();

            SelectedType = DeviceType.Printer;
            SelectedStatus = DeviceStatus.InUse;
        }

        private void LoadDevicesFromDb()
        {
            var devices = _repository.GetAllDevices();
            Devices.Clear();
            foreach (var d in devices)
                Devices.Add(d);
        }

        [RelayCommand]
        private void AddDevice()
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                var newDevice = new Device
                {
                    Name = Name,
                    Type = SelectedType,
                    Status = SelectedStatus
                };

                _repository.AddDevice(newDevice);

                Devices.Add(newDevice);
                Name = string.Empty;
            }
        }

        [RelayCommand]
        private void DeleteDevice(Device device)
        {
            if (device == null) return;

            _repository.DeleteDevice(device);
            Devices.Remove(device);
        }
        [RelayCommand]
        public void UpdateDevice(Device device)
        {
            if (device == null) return;

            _repository.UpdateDevice(device);
        }
    }
}

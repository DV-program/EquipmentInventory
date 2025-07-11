using EquipmentInventory.Models;
using EquipmentInventory.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace EquipmentInventory
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Device _editedDevice;

        // Делаем сохранение бд после изменения таблицы
        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                Dispatcher.InvokeAsync(() =>
                {
                    var device = e.Row.Item as Device;
                    if (device != null)
                    {
                        if (DataContext is MainViewModel vm)
                        {
                            vm.UpdateDevice(device);
                        }
                    }
                }, DispatcherPriority.Background);
            }
        }
    }
}

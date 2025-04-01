using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TuringSmartScreenClient.Models;
using TuringSmartScreenClient.Views;

namespace TuringSmartScreenClient.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private NavigationItem _selectedItem = null!;
        public ObservableCollection<NavigationItem> NavigationItems { get; set; } = null!;
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowViewModel()
        {
            InitializeNavigationItems();
        }

        private void InitializeNavigationItems()
        {
            NavigationItems =
                [
                    new NavigationItem
                    {
                        Title = "主页",
                        Content = new HomePage()
                    },
                    new NavigationItem
                    {
                        Title = "设备管理",
                        Content = new DeviceManagementPage()
                    },
                    new NavigationItem
                    {
                        Title = "主题市场",
                        Content = new ThemeMarketPage()
                    },
                    new NavigationItem
                    {
                        Title = "系统设置",
                        Content = new SystemSettingsPage()
                    },
                    new NavigationItem
                    {
                        Title = "关于",
                        Content = new AboutPage()
                    }
                ];

            // 设置默认选中项
            SelectedItem = NavigationItems[0];
        }

        public NavigationItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
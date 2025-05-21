using System.Collections.ObjectModel;
using System.Windows.Input;
using FeawosCoffeeApp.Services;
using FeawosCoffeeApp.Model;
using System.ComponentModel;
using FeawosCoffeeApp.View;

namespace FeawosCoffeeApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly FeawosCoffeeAppService feawosCoffeeAppService;

        public ObservableCollection<GroupedMenuItem> MenuItems { get; private set; }
        public ICommand ItemSelectedCommand { get; }
        public ICommand ViewOrderCommand { get; }
        public ICommand ViewOrderHistoryCommand { get; }
        public ICommand ShowAllMenuItemsCommand { get; }
        public ICommand ShowHotDrinksCommand { get; }
        public ICommand ShowFoodCommand { get; }
        public ICommand ShowColdDrinksCommand { get; }

        public MainViewModel(FeawosCoffeeAppService service)
        {
            feawosCoffeeAppService = service;

            // Load menu items from service
            var groupedMenuItems = feawosCoffeeAppService.GetMenuItems();
            MenuItems = new ObservableCollection<GroupedMenuItem>(groupedMenuItems);

            // Initialize commands
            ItemSelectedCommand = new Command<Model.MenuItem>(OnItemSelected);
            ViewOrderCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(OrderPage)));
            ViewOrderHistoryCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(OrderHistoryPage)));
            ShowAllMenuItemsCommand = new Command(ShowAllMenuItems);
            ShowHotDrinksCommand = new Command(ShowHotDrinks);
            ShowFoodCommand = new Command(ShowFood);
            ShowColdDrinksCommand = new Command(ShowColdDrinks);
        }

        private void ShowAllMenuItems()
        {
            // Get all menu items
            var groupedMenuItems = feawosCoffeeAppService.GetMenuItems();
            MenuItems = new ObservableCollection<GroupedMenuItem>(groupedMenuItems);
            OnPropertyChanged(nameof(MenuItems));
        }

        private void ShowHotDrinks()
        {
            // Filter by HotDrinks category
            var groupedMenuItems = feawosCoffeeAppService.GetMenuItems()
                .Where(group => group.Category == MenuItemCategory.HotDrinks.ToString())
                .ToList();
            MenuItems = new ObservableCollection<GroupedMenuItem>(groupedMenuItems);
            OnPropertyChanged(nameof(MenuItems));
        }

        private void ShowFood()
        {
            // Filter by Food category
            var groupedMenuItems = feawosCoffeeAppService.GetMenuItems()
                .Where(group => group.Category == MenuItemCategory.Food.ToString())
                .ToList();
            MenuItems = new ObservableCollection<GroupedMenuItem>(groupedMenuItems);
            OnPropertyChanged(nameof(MenuItems));
        }

        private void ShowColdDrinks()
        {
            // Filter by ColdDrinks category
            var groupedMenuItems = feawosCoffeeAppService.GetMenuItems()
                .Where(group => group.Category == MenuItemCategory.ColdDrinks.ToString())
                .ToList();
            MenuItems = new ObservableCollection<GroupedMenuItem>(groupedMenuItems);
            OnPropertyChanged(nameof(MenuItems));
        }

        private async void OnItemSelected(Model.MenuItem selectedItem)
        {
            if (selectedItem != null)
            {
                var navigationParameter = new Dictionary<string, object>
            {
                { "SelectedMenuItem", selectedItem }
            };
                await Shell.Current.GoToAsync(nameof(DetailsPage), navigationParameter);
            }
        }

        private Model.MenuItem _selectedItem;
        public Model.MenuItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public event PropertyChangedEventHandler ? CustomPropertyChanged;
        protected new virtual void OnPropertyChanged(string propertyName)
        {
            CustomPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
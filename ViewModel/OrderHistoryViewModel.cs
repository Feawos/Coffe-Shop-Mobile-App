using System.Collections.ObjectModel;
using System.ComponentModel;
using FeawosCoffeeApp.Services;
using FeawosCoffeeApp.Model;


namespace FeawosCoffeeApp.ViewModel
{
    public class OrderHistoryViewModel : BaseViewModel
    {
        private readonly FeawosCoffeeAppService feawosCoffeeAppService;

        public ObservableCollection<Order> Orders { get; }

        public OrderHistoryViewModel(FeawosCoffeeAppService service)
        {
            feawosCoffeeAppService = service;
            Orders = new ObservableCollection<Order>(feawosCoffeeAppService.GetOrderHistoryForToday());
        }

        private List<Order> GetOrderHistoryForToday()
        {
            // Implement your logic to retrieve orders for today
            return new List<Order>(); // Example
        }

        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get => _orderDate;
            set
            {
                _orderDate = value;
                OnPropertyChanged(nameof(OrderDate));
            }
        }

        // Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler CustomPropertyChanged;
        protected new virtual void OnPropertyChanged(string propertyName)
        {
            CustomPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _orderNumber;
        public int OrderNumber
        {
            get => _orderNumber;
            set
            {
                _orderNumber = value;
                OnPropertyChanged(nameof(OrderNumber));
            }
        }

    }
}

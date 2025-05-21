using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using FeawosCoffeeApp.Services;
using FeawosCoffeeApp.Model;


namespace FeawosCoffeeApp.ViewModel
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        private readonly FeawosCoffeeAppService feawosCoffeeAppService;

        public ObservableCollection<OrderItem> OrderItems { get; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        private string _orderSummary;
        public string OrderSummary
        {
            get => _orderSummary;
            private set
            {
                _orderSummary = value;
                OnPropertyChanged(nameof(OrderSummary));
            }
        }

        public ICommand PlaceOrderCommand { get; }

        public OrderViewModel(FeawosCoffeeAppService service)
        {
            feawosCoffeeAppService = service;
            OrderItems = new ObservableCollection<OrderItem>();
            PlaceOrderCommand = new Command(PlaceOrder);
        }

        private void PlaceOrder()
        {
            if (string.IsNullOrEmpty(CustomerName) || string.IsNullOrEmpty(CustomerPhone))
            {
                OrderSummary = "Please enter customer details.";
                OnPropertyChanged(nameof(OrderSummary));
                return;
            }

            Customer customer = new Customer(CustomerName, CustomerPhone);
            var order = feawosCoffeeAppService.CreateOrder(customer, new List<OrderItem>(OrderItems));
            feawosCoffeeAppService.SaveOrderHistoryToFile("orders.txt");

            OrderSummary = $"Order placed! Total: {order.GetTotalAmount():C}";
            OnPropertyChanged(nameof(OrderSummary));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


using FeawosCoffeeApp.Model;


namespace FeawosCoffeeApp.Services
{
    public class FeawosCoffeeAppService
    {
        private readonly List<Model.MenuItem> menuItems;
        private readonly OrderHistory orderHistory;
        private int nextOrderNumber;

        public FeawosCoffeeAppService()
        {
            // Initialize menu items
            menuItems = new List<Model.MenuItem>
            {
                new Model.MenuItem(1, "Cappuccino", "cappuccino.jpg", 4.50m, MenuItemCategory.HotDrinks),
                new Model.MenuItem(2, "Espresso", "espresso.jpg", 3.00m, MenuItemCategory.HotDrinks),
                new Model.MenuItem(3, "Hot Chocolate", "hot_chocolate.jpg", 5.00m, MenuItemCategory.HotDrinks),
                new Model.MenuItem(4, "Latte", "latte.jpg", 4.00m, MenuItemCategory.HotDrinks),
                new Model.MenuItem(5, "Strawberries Cream Frappe", "strawberries_cream_frappe.jpg", 5.50m, MenuItemCategory.ColdDrinks),
                new Model.MenuItem(6, "Chocolate Cream Frappe", "chocolate_cream_frappe.jpg", 5.00m, MenuItemCategory.ColdDrinks),
                new Model.MenuItem(7, "Iced Caramel Macchiato", "iced_caramel_macchiato.jpg", 5.00m, MenuItemCategory.ColdDrinks),
                new Model.MenuItem(8, "Iced Latte", "iced_latte.jpg", 5.00m, MenuItemCategory.ColdDrinks),
                new Model.MenuItem(9, "Bacon Double Cheeseburger", "bacon_double_cheeseburger.jpg", 4.50m, MenuItemCategory.Food),
                new Model.MenuItem(10, "Cheese Crispy Chicken Sandwich", "cheese_crispy_chicken_sandwich.jpg", 4.00m, MenuItemCategory.Food),
                new Model.MenuItem(11, "Cheese Crispy Chicken Wrap", "cheese_crispy_chicken_wrap.jpg", 5.00m, MenuItemCategory.Food),
                new Model.MenuItem(12, "Cheese Fries", "cheese_fries.jpg", 3.00m, MenuItemCategory.Food)
            };

            // Initialize order history
            orderHistory = new OrderHistory();
            nextOrderNumber = 1;
        }

        public List<GroupedMenuItem> GetMenuItems()
        {
            return menuItems
                .GroupBy(item => item.Category)
                .Select(group => new GroupedMenuItem(group.Key.ToString(), new List<Model.MenuItem>(group)))
                .ToList();
        }

        public Order CreateOrder(Customer customer, List<OrderItem> orderItems)
        {
            var order = new Order(nextOrderNumber++, customer);
            foreach (var item in orderItems)
            {
                order.AddItem(item);
            }
            orderHistory.AddOrder(order);
            return order;
        }

        public List<Order> GetOrderHistoryForToday()
        {
            return orderHistory.GetOrdersForToday();
        }

        public Model.MenuItem GetMenuItemById(int id)
        {
            return menuItems.FirstOrDefault(m => m.Id == id);
        }

        public void SaveOrderHistoryToFile(string filePath)
        {
            orderHistory.SaveOrdersToFile(filePath);
        }
    }
}

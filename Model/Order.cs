using System.Text.Json.Serialization;

namespace FeawosCoffeeApp.Model
{
    public class Order
    {
        public int OrderNumber { get; private set; }
        public Customer Customer { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }
        public DateTime OrderDate { get; private set; }

        public Order(int orderNumber, Customer customer)
        {
            OrderNumber = orderNumber;
            Customer = customer;
            OrderItems = new List<OrderItem>();
            OrderDate = DateTime.Now;
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
        }

        public decimal GetTotalAmount()
        {
            return OrderItems.Sum(i => i.Quantity * i.MenuItem.Price);
        }
    }

    public class OrderItem
    {
        public MenuItem MenuItem { get; }
        public int Quantity { get; }

        public OrderItem(MenuItem menuItem, int quantity)
        {
            MenuItem = menuItem;
            Quantity = quantity;
        }
    }
}

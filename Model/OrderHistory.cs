using System.Text.Json.Serialization;

namespace FeawosCoffeeApp.Model
{
    public class OrderHistory
    {
        private List<Order> orders;
        private int nextOrderNumber;

        public OrderHistory()
        {
            orders = new List<Order>();
            nextOrderNumber = 1;
        }

        public Order CreateOrder(Customer customer)
        {
            Order newOrder = new Order(nextOrderNumber++, customer);
            orders.Add(newOrder);
            return newOrder;
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetOrdersForToday()
        {
            return orders.Where(order => order.OrderDate.Date == DateTime.Today).ToList();
        }

        public void SaveOrdersToFile(string filePath)
        {
            string fullPath = Path.Combine(FileSystem.AppDataDirectory, filePath);

            using (StreamWriter writer = new StreamWriter(fullPath, true))
            {
                foreach (var order in GetOrdersForToday())
                {
                    writer.WriteLine(order);
                }
            }
        }
    }
}

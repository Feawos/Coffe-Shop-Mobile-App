using System.Text.Json.Serialization;

namespace FeawosCoffeeApp.Model
{
    public class Customer
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}

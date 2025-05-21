

namespace FeawosCoffeeApp.Model
{
    public enum MenuItemCategory
    {
        HotDrinks,
        Food,
        ColdDrinks
    }
    public class MenuItem(int id, string name, string image, decimal price, MenuItemCategory category)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Image { get; set; } = image;
        public decimal Price { get; set; } = price;
        public MenuItemCategory Category { get; set; } = category;
    }
    public class GroupedMenuItem(string category, List<MenuItem> items)
    {
        public string Category { get; } = category;
        public List<MenuItem> Items { get; } = items;
    }
}

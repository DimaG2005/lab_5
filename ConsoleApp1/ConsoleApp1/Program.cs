using System;
using System.Collections.Generic;
using System.Linq;

// Інтерфейс для пошуку товарів
public interface ISearchable
{
    List<Tovar> SearchByPrice(decimal price);
    List<Tovar> SearchByCategory(string category);
    // Додайте інші методи пошуку за потребою (наприклад, по рейтингу)
}

// Клас Товар
public class Tovar
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    // Додайте інші атрибути та методи за потребою
}

// Клас Користувач
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Tovar> PurchaseHistory { get; set; }
    // Додайте методи та інші атрибути для управління користувачами
}

// Клас Замовлення
public class Order
{
    public List<Tuple<Tovar, int>> OrderDetails { get; set; } // товар та кількість
    public decimal TotalCost { get; set; }
    public string Status { get; set; }
    // Додайте інші атрибути та методи для управління замовленнями
}

// Клас Магазин
public class Shop : ISearchable
{
    private List<User> users;
    private List<Tovar> products;
    private List<Order> orders;

    public Shop()
    {
        users = new List<User>();
        products = new List<Tovar>();
        orders = new List<Order>();
    }

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void AddProduct(Tovar product)
    {
        products.Add(product);
    }

    public void CreateOrder(Order order)
    {
        orders.Add(order);
    }

    // Реалізація методів інтерфейсу ISearchable
    public List<Tovar> SearchByPrice(decimal price)
    {
        return products.Where(p => p.Price == price).ToList();
    }

    public List<Tovar> SearchByCategory(string category)
    {
        return products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    // Додайте інші методи управління магазином

    public static void Main(string[] args)
    {
        // Основний код програми
        Shop myShop = new Shop();

        // Додавання товарів
        Tovar product1 = new Tovar { Name = "Product 1", Price = 10.99m, Category = "Category 1", Description = "Description 1" };
        myShop.AddProduct(product1);

        Tovar product2 = new Tovar { Name = "Product 2", Price = 20.49m, Category = "Category 2", Description = "Description 2" };
        myShop.AddProduct(product2);

        // Додавання користувачів
        User user1 = new User { Username = "User1", Password = "password1", PurchaseHistory = new List<Tovar>() };
        myShop.AddUser(user1);

        // Створення замовлення
        Order order1 = new Order { OrderDetails = new List<Tuple<Tovar, int>> { new Tuple<Tovar, int>(product1, 2) }, TotalCost = 21.98m, Status = "In progress" };
        myShop.CreateOrder(order1);

        // Пошук товарів за різними критеріями
        List<Tovar> productsInCategory2 = myShop.SearchByCategory("Category 2");
        foreach (var product in productsInCategory2)
        {
            Console.WriteLine(product.Name);
        }
    }
}

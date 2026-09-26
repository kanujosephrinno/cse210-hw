using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "New York",
            "USA"
        );

        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);

        Product product1 = new Product("Laptop", "P001", 800, 1);

        Product product2 = new Product("Mouse", "P002", 25, 2);

        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotal()}");

        Address address2 = new Address(
            "12 Wilkinson Road",
            "Freetown",
            "Western Area",
            "Sierra Leone"
        );

        Customer customer2 = new Customer("Joseph Kanu", address2);

        Order order2 = new Order(customer2);

        Product product3 = new Product("Keyboard", "P003", 50, 1);

        Product product4 = new Product("Headphones", "P004", 40, 2);

        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotal()}");
    }
}
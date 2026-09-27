using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "Provo",
            "Utah",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product(
            "Keyboard",
            "P001",
            25.00,
            2
        ));

        order1.AddProduct(new Product(
            "Mouse",
            "P002",
            15.00,
            1
        ));

        order1.AddProduct(new Product(
            "Headphones",
            "P003",
            30.00,
            1
        ));


        Address address2 = new Address(
            "Rua das Flores, 200",
            "Salvador",
            "Bahia",
            "Brazil"
        );

        Customer customer2 = new Customer(
            "Maria Silva",
            address2
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product(
            "Notebook Stand",
            "P004",
            40.00,
            1
        ));

        order2.AddProduct(new Product(
            "USB Cable",
            "P005",
            10.00,
            3
        ));


        Console.WriteLine("ORDER 1");
        Console.WriteLine();

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():F2}");


        Console.WriteLine();
        Console.WriteLine("--------------------------");
        Console.WriteLine();


        Console.WriteLine("ORDER 2");
        Console.WriteLine();

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():F2}");
    }
}
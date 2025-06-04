class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products
        Product product1 = new Product("Widget", "W123", 10.0m, 2);
        Product product2 = new Product("Gadget", "G456", 15.5m, 1);
        Product product3 = new Product("Thingamajig", "T789", 7.25m, 3);
        Product product4 = new Product("Doodad", "D321", 12.0m, 2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display order 1 details
        System.Console.WriteLine("Order 1 Packing Label:");
        System.Console.WriteLine(order1.GetPackingLabel());
        System.Console.WriteLine("Order 1 Shipping Label:");
        System.Console.WriteLine(order1.GetShippingLabel());
        System.Console.WriteLine($"Order 1 Total Price: ${order1.GetTotalPrice():F2}\n");

        // Display order 2 details
        System.Console.WriteLine("Order 2 Packing Label:");
        System.Console.WriteLine(order2.GetPackingLabel());
        System.Console.WriteLine("Order 2 Shipping Label:");
        System.Console.WriteLine(order2.GetShippingLabel());
        System.Console.WriteLine($"Order 2 Total Price: ${order2.GetTotalPrice():F2}");
    }
}

class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Trim().ToUpper() == "USA";
    }

    public override string ToString()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }
}

class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal GetTotalPrice()
    {
        return price * quantity;
    }

    public string GetPackingLabel()
    {
        return $"{name} (ID: {productId}) x{quantity}";
    }
}

class Order
{
    private Customer customer;
    private System.Collections.Generic.List<Product> products = new System.Collections.Generic.List<Product>();

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalPrice();
        }
        // Shipping: $5 USA, $35 international
        total += customer.GetAddress().IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (var product in products)
        {
            sb.AppendLine(product.GetPackingLabel());
        }
        return sb.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetAddress()}";
    }
}
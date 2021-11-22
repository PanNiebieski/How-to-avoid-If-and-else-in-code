public class Product
{
    private readonly string id;

    private Product()
    {
        this.id = Guid.NewGuid().ToString("D");
    }

    public string Id => id;
    public int Price { get; private set; }

    public string GenerateOutput(IProductOutputStrategy strategy) =>
        strategy.ConvertProductToString(this);

    public static Product CreateNew(int price)
    {
        if (price <= 0) throw new ArgumentException
                ("price must be a positive number");

        var order = new Product
        {
            Price = price,
        };

        return order;
    }
}



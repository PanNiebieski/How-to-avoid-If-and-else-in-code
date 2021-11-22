public class Order
{
    private readonly string id;

    private Order()
    {
        this.id = Guid.NewGuid().ToString("D");
    }

    public string Id => id;
    public int Sum { get; private set; }

    public string GenerateOutput(IOrderOutputStrategy strategy) =>
        strategy.ConvertOrderToString(this);

    public static Order CreateNew(int orderSum)
    {
        if (orderSum <= 0) throw new ArgumentException
                ("sum must be a positive number");

        var order = new Order
        {
            Sum = orderSum,
        };

        return order;
    }
}

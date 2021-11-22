[OutputFormatterName("PlainText")]
public class OrderPlainTextOutput : IProductOutputStrategy
{
    public string ConvertOrderToString(Product order)
    {
        return $"Id: {order.Id}{Environment.NewLine}Sum: {order.Sum}";
    }
}



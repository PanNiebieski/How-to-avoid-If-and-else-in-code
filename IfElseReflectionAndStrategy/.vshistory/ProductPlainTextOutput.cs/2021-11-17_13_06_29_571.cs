[OutputFormatterName("PlainText")]
public class OrderPlainTextOutput : IOrderOutputStrategy
{
    public string ConvertOrderToString(Order order)
    {
        return $"Id: {order.Id}{Environment.NewLine}Sum: {order.Sum}";
    }
}



[ProductFormatterName("PlainText")]
public class ProductPlainTextOutput : IProductOutputStrategy
{
    public string ConvertOrderToString(Product order)
    {
        return $"Id: {order.Id}{Environment.NewLine}Sum: {order.Sum}";
    }
}



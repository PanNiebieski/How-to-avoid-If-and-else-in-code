[ProductFormatterName("PlainText")]
public class ProductPlainTextOutput : IProductOutputStrategy
{
    public string ConvertProductToString(Product order)
    {
        return $"Id: {order.Id}{Environment.NewLine}Sum: {order.Sum}";
    }
}



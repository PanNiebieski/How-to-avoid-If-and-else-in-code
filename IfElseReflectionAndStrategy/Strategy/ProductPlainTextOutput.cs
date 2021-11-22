[ProductFormatterName(FormatType.PlainText)]
public class ProductPlainTextOutput : IProductOutputStrategy
{
    public string ConvertProductToString(Product pro)
    {
        return $"Id: {pro.Id}{Environment.NewLine}Price: {pro.Price}";
    }
}



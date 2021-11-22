using System.Text.Json;

[ProductFormatterName(FormatType.Json)]
public class ProductJsonOutput : IProductOutputStrategy
{
    public string ConvertProductToString(Product order)
    {
        string json = JsonSerializer.Serialize(order);
        return json;
    }
}



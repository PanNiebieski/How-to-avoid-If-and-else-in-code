using System.Text.Json;

[ProductFormatterName("Json")]
public class ProductJsonOutput : IProductOutputStrategy
{
    public string ConvertOrderToString(Product order)
    {
        string json = JsonSerializer.Serialize(order);
        return json;
    }
}



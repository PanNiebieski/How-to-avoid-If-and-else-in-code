using System.Text.Json;

[OutputFormatterName("Json")]
public class ProductJsonOutput : IProductOutputStrategy
{
    public string ConvertOrderToString(Product order)
    {
        string json = JsonSerializer.Serialize(order);
        return json;
    }
}



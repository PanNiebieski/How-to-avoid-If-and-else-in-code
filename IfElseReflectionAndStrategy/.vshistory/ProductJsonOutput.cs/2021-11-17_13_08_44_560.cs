using System.Text.Json;

[OutputFormatterName("Json")]
public class OrderJsonOutput : IOrderOutputStrategy
{
    public string ConvertOrderToString(Product order)
    {
        string json = JsonSerializer.Serialize(order);
        return json;
    }
}



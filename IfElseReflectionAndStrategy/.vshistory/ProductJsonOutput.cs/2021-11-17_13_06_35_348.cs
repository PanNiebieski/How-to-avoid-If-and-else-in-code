using System.Text.Json;

[OutputFormatterName("Json")]
public class OrderJsonOutput : IOrderOutputStrategy
{
    public string ConvertOrderToString(Order order)
    {
        string json = JsonSerializer.Serialize(order);
        return json;
    }
}



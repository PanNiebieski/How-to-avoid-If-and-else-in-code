using System.Text.Json;

[ProductFormatterName(FormatType.Json)]
public class ProductJsonOutput : IProductOutputStrategy
{
    public string ConvertProductToString(Product pro)
    {
        string json = JsonSerializer.Serialize(pro);
        return json;
    }
}



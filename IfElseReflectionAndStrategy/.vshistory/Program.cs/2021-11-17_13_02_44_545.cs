using System.Text.Json;

string json = PrintOrder(Order.CreateNew(10), "Json");
string plain = PrintOrder(Order.CreateNew(10), "PlainText");
Console.WriteLine(json);
Console.WriteLine(plain);

Console.WriteLine(Environment.NewLine);

/*
 * Dynamic
 */
string json2 = PrintOrder2(Order.CreateNew(10), "Json");
string plain2 = PrintOrder2(Order.CreateNew(10), "PlainText");
Console.WriteLine(json2);
Console.WriteLine(plain2);




static string PrintOrder(Order order, string formatType)
{
    // Guard clauses left out for brevity

    string result = string.Empty;

    if (formatType == "Json")
    {
        result = JsonSerializer.Serialize(order);
    }
    else if (formatType == "PlainText")
    {
        result = $"Id: {order.Id}\nSum: {order.Sum}";
    }
    else
    {
        result = "Unknown format";
    }

    return result;
}

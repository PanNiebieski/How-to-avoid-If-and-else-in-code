using System.Reflection;
using System.Text.Json;

string json = PrintOrder(Order.CreateNew(10), "Json");
string plain = PrintOrder(Order.CreateNew(10), "PlainText");
Console.WriteLine(json);
Console.WriteLine(plain);

Console.WriteLine(Environment.NewLine);

/*
 * Dynamiczne
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



static string PrintOrder2(Order order, string formatType)
{
    // Dynamic type discovery process that builds a dictionary
    Dictionary<string, Type> formatterTypes = Assembly
        .GetExecutingAssembly()
        .GetExportedTypes()
        .Where(type => type.GetInterfaces()
        .Contains(typeof(IOrderOutputStrategy)))
        .ToDictionary
        (type => type.GetCustomAttribute<OutputFormatterName>().DisplayName);

    Type chosenFormatter = formatterTypes[formatType];

    // Try instantiate the formatter -- could have utilized a DI framework here instead
    IOrderOutputStrategy strategy = 
        Activator.CreateInstance(chosenFormatter) as IOrderOutputStrategy;

    if (strategy is null) 
        throw new InvalidOperationException("No valid formatter selected");

    // Execute strategy method
    string result = strategy.ConvertOrderToString(order);
    return result;
}

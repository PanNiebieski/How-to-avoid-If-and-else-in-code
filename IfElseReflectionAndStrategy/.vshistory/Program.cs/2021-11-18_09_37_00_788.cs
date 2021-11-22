using System.Reflection;
using System.Text.Json;

string json = Print(Product.CreateNew(10), "Json");
string plain = Print(Product.CreateNew(10), "PlainText");
Console.WriteLine(json);
Console.WriteLine(plain);

Console.WriteLine(Environment.NewLine);

/*
 * Dynamiczne
 */
string json2 = Print2(Product.CreateNew(10), FormatType.Json);
string plain2 = Print2(Product.CreateNew(10), FormatType.PlainText);
Console.WriteLine(json2);
Console.WriteLine(plain2);




static string Print(Product pr, string formatType)
{


    string result = string.Empty;

    if (formatType == "Json")
    {
        result = JsonSerializer.Serialize(pr);
    }
    else if (formatType == "PlainText")
    {
        result = $"Id: {pr.Id}\nSum: {pr.Price}";
    }
    else
    {
        result = "Unknown format";
    }

    return result;
}



static string Print2(Product pr, FormatType formatType)
{
    // Dynamiczne szukanie typów i budowanie słownika
    Dictionary<FormatType, Type> formatterTypes = Assembly
        .GetExecutingAssembly()
        .GetExportedTypes()
        .Where(type => type.GetInterfaces()
        .Contains(typeof(IProductOutputStrategy)))
        .ToDictionary
        (type =>
        type.GetCustomAttribute<ProductFormatterName>()
        .DisplayName);

    Type chosenFormatter = formatterTypes[formatType];

    // 
    // Tworzenie instancji naszej strategi
    // -- zawsze możesz użyć Wstrzykiwania zależności
    IProductOutputStrategy strategy = 
        Activator.CreateInstance(chosenFormatter) as IProductOutputStrategy;

    if (strategy is null) 
        throw new InvalidOperationException("No valid formatter selected");

    // Wykonanie odpowiednej strategii
    string result = strategy.ConvertProductToString(pr);
    return result;
}


public enum FormatType
{
    Json,
    PlainText
}

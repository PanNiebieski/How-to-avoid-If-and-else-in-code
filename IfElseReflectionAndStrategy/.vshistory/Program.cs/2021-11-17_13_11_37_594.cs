﻿using System.Reflection;
using System.Text.Json;

string json = Print(Product.CreateNew(10), "Json");
string plain = Print(Product.CreateNew(10), "PlainText");
Console.WriteLine(json);
Console.WriteLine(plain);

Console.WriteLine(Environment.NewLine);

/*
 * Dynamiczne
 */
string json2 = Print2(Product.CreateNew(10), "Json");
string plain2 = Print2(Product.CreateNew(10), "PlainText");
Console.WriteLine(json2);
Console.WriteLine(plain2);




static string Print(Product pr, string formatType)
{
    // Guard clauses left out for brevity

    string result = string.Empty;

    if (formatType == "Json")
    {
        result = JsonSerializer.Serialize(pr);
    }
    else if (formatType == "PlainText")
    {
        result = $"Id: {pr.Id}\nSum: {pr.Sum}";
    }
    else
    {
        result = "Unknown format";
    }

    return result;
}



static string Print2(Product pr, string formatType)
{
    // Dynamic type discovery process that builds a dictionary
    Dictionary<string, Type> formatterTypes = Assembly
        .GetExecutingAssembly()
        .GetExportedTypes()
        .Where(type => type.GetInterfaces()
        .Contains(typeof(IProductOutputStrategy)))
        .ToDictionary
        (type => type.GetCustomAttribute<ProductFormatterName>().DisplayName);

    Type chosenFormatter = formatterTypes[formatType];

    // Try instantiate the formatter -- could have utilized a DI framework here instead
    IProductOutputStrategy strategy = 
        Activator.CreateInstance(chosenFormatter) as IProductOutputStrategy;

    if (strategy is null) 
        throw new InvalidOperationException("No valid formatter selected");

    // Execute strategy method
    string result = strategy.ConvertProductToString(pr);
    return result;
}

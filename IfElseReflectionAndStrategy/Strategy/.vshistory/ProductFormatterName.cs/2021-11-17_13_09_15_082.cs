[AttributeUsage(AttributeTargets.Class)]
public class ProductFormatterName : Attribute
{
    public ProductFormatterName(string displayName)
    {
        DisplayName = displayName;
    }
    public string DisplayName { get; }
}



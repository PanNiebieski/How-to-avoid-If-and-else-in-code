[AttributeUsage(AttributeTargets.Class)]
public class ProductFormatterName : Attribute
{
    public ProductFormatterName(FormatType displayName)
    {
        DisplayName = displayName;
    }
    public FormatType DisplayName { get; }
}



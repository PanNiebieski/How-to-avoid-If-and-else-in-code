public abstract class BeerState
{
    public virtual void Drink(Beer sw)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Can't drink");
        Console.ResetColor();
    }

    public virtual void Fill(Beer sw)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Can't fill");
        Console.ResetColor();
    }
}


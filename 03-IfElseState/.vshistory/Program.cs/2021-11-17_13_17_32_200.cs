




public class Beer
{
    public BeerState State = new BeerFullState();

    public void Fill() { State.Fill(this); }
    public void Drink() { State.Drink(this); }
}



public class BeerFullState : BeerState
{
    public BeerFullState()
    {
        Console.WriteLine("Beer is in FullState");
    }

    public override void Drink(Beer sw)
    {
        Console.WriteLine("Drink -> Drinking beer");
        sw.State = new BeerEmptyState();
    }
}


public class BeerEmptyState : BeerState
{
    public BeerEmptyState()
    {
        Console.WriteLine("Beer is in EmptyState");
    }

    public override void Fill(Beer sw)
    {
        Console.WriteLine("Fill -> Pouring beer");
        sw.State = new BeerFullState();
    }
}


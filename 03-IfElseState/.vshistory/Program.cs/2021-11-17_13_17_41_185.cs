

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


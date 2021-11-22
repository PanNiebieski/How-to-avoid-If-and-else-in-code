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


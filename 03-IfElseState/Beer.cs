public class Beer
{
    public BeerState State = new BeerFullState();

    public void Fill() { State.Fill(this); }
    public void Drink() { State.Drink(this); }
}






public class Phone
{
    public TriggerPhone Trigger { get; set; }
    public PhoneState State { get; set; }

    //Dodać tutaj akcję/metodę
    public void Do()
    {
        Console.WriteLine("WOO");
    }

    public Phone(TriggerPhone t, PhoneState state)
    {
        Trigger = t;
        State = state;
    }
}

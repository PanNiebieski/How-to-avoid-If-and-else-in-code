



public class Phone
{
    public TriggerPhone Trigger { get; set; }
    public PhoneState State { get; set; }

    //Dodać tutaj akcję/metodę

    public Phone(TriggerPhone t, PhoneState state)
    {
        Trigger = t;
        State = state;
    }
}

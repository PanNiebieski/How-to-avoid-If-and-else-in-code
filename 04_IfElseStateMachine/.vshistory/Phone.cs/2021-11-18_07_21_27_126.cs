



public class Phone
{
    public TriggerPhone Trigger { get; set; }
    public PhoneState State { get; set; }


    public Phone(TriggerPhone t, PhoneState state)
    {
        Trigger = t;
        State = state;
    }
}



public class StateBuilder
{
    public List<Phone> PermittedTriggers { get; set; }
    public StateBuilder OnEntry(Action entryAction)
    {

    }
}

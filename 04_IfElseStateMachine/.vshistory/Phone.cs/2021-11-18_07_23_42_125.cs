



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



public class StateController
{
    public List<Phone> PermittedStatesAndTriggers { get; set; }

    public Action OnEntry { get; set; }

}

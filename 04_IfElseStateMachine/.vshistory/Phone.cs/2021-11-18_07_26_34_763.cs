



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
    public List<Phone> PermittedStatesAndTriggers { get;  }

    public Action Action { get;  }

    public StateController(List<Phone> permittedStatesAndTriggers,
        Action action)
    {
        PermittedStatesAndTriggers = permittedStatesAndTriggers;
        Action = action;
    }

    public void CallAction()
    {
        Action?.Invoke();
    }
}

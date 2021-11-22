public class StateController
{
    public List<Phone> PermittedStatesAndTriggers { get;  }

    public Action OnEntryAction { get;  }

    public StateController(List<Phone> permittedStatesAndTriggers,
        Action action)
    {
        PermittedStatesAndTriggers = permittedStatesAndTriggers;
        OnEntryAction = action;
    }

    public void CallAction()
    {
        OnEntryAction?.Invoke();
    }
}

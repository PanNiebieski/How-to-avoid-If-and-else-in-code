
Dictionary<PhoneState, List<Phone>> rules0
=  new Dictionary<PhoneState, List<Phone>>
{
    [PhoneState.OffHook] = new List<Phone>
    {
          new Phone(TriggerPhone.CallDialed, PhoneState.Connecting)
    },

    [PhoneState.Connecting] = new List<Phone>
    {
            new Phone(TriggerPhone.HungUp, PhoneState.OffHook),
            new Phone(TriggerPhone.CallConnected, PhoneState.Connected)
    },
    [PhoneState.Connected] = new List<Phone>
    {
             new Phone(TriggerPhone.HungUp, PhoneState.OffHook),
             new Phone(TriggerPhone.LeftMessage, PhoneState.Connected),
    },
};



PhoneState state = PhoneState.OffHook;







public enum PhoneState
{
    OffHook,
    Connecting,
    Connected,
    OnHold
}


public enum TriggerPhone
{
    CallDialed,
    HungUp,
    CallConnected,
    PlacedOnHook,
    TakenOffHold,
    LeftMessage
}



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

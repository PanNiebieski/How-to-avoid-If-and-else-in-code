
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

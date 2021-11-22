
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
             new Phone(TriggerPhone.EndThis, PhoneState.EndThis)
    },
    [PhoneState.EndThis] = new List<Phone>
    {

    },
};


PhoneState state = PhoneState.OffHook;


do
{
    Console.WriteLine($"The phone is currently {state}");
    Console.WriteLine("Select a trigger:");
    for (var i = 0; i < rules0[state].Count; i++)
    {
        var phone = rules0[state][i];
        Console.WriteLine($"{i}. {phone.Trigger}");
    }

    int input = int.Parse(Console.ReadLine());
    var phone1 = rules0[state][input];
    state = phone1.State;

} while (rules0[state].Count != 0);








Dictionary<PhoneState, List<Phone>> rules1
= new Dictionary<PhoneState, List<Phone>>
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
             new Phone(TriggerPhone.EndThis, PhoneState.EndThis)
    },
    [PhoneState.EndThis] = new List<Phone>
    {

    },
};


public 



















public class StateControler<T1, T2>
{
    public T1 Trigger { get; protected set; }
    public T2 State { get; protected set; }

    public StateControler(T2 beginstate)
    {
        State = beginstate;
    }

    public virtual void Do(T1 trigger) { }
}


public class StatePhoneContoler : StateControler<TriggerPhone, PhoneState>
{
    public StatePhoneContoler() :
        base(PhoneState.OffHook)
    {

    }

    public override void Do(TriggerPhone trigger)
    {
        if (trigger == TriggerPhone.HungUp)
            State = PhoneState.OffHook;
        if (trigger == TriggerPhone.CallConnected)
            State = PhoneState.Connected;
    }
}

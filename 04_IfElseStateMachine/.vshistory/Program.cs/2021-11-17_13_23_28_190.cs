
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

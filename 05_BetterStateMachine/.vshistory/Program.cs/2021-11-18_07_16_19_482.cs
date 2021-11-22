using Stateless;



var call = new StateMachine<PhoneState, TriggerPhone>
    (PhoneState.OffHook);

call.Configure(PhoneState.OffHook)
    .Permit(TriggerPhone.CallDialed, PhoneState.Connecting)
    .OnEntry(() => WriteState(call));


call.Configure(PhoneState.Connecting)
    .Permit(TriggerPhone.PlacedOnHook, PhoneState.OffHook)
    .Permit(TriggerPhone.CallConnected, PhoneState.Connected)
    .OnEntry(() => WriteState(call));

call.Configure(PhoneState.Connected)
    .PermitReentry(TriggerPhone.LeftMessage)//, PhoneState.Connected
    .Permit(TriggerPhone.PlacedOnHook, PhoneState.OffHook)
    .Permit(TriggerPhone.TakenOffHold, PhoneState.OnHook)
    .OnEntry(() => WriteState(call));


List<TriggerPhone> alltriggers = new List<TriggerPhone>();

while (true)
{
    state.PermittedTriggers
}
call.Fire(TriggerPhone.CallDialed);





void WriteState(StateMachine<PhoneState, TriggerPhone> state)
{
    Console.WriteLine(state.State);

    Console.WriteLine("----PermittedTriggers----");
    foreach (var item in state.PermittedTriggers)
    {
        Console.WriteLine(item);
    }
}

public enum PhoneState
{
    OffHook,
    Connecting,
    Connected,
    OnHook
}

public enum TriggerPhone
{
    CallDialed = 0,
    HungUp = 1,
    CallConnected = 2,
    PlacedOnHook = 3,
    TakenOffHold = 4,
    LeftMessage = 5 
}


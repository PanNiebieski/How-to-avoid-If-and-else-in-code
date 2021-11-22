using Stateless;



var call = new StateMachine<PhoneState, TriggerPhone>
    (PhoneState.OffHook);

call.Configure(PhoneState.OffHook)
    .Permit(TriggerPhone.CallDialed, PhoneState.Connecting)
    .OnEntry(() => Console.WriteLine(call.)));

call.Configure(PhoneState.Connecting)
    .Permit(TriggerPhone.PlacedOnHook, PhoneState.OffHook)
    .Permit(TriggerPhone.CallConnected, PhoneState.Connected);

call.Configure(PhoneState.Connected)
    .PermitReentry(TriggerPhone.LeftMessage)//, PhoneState.Connected
    .Permit(TriggerPhone.PlacedOnHook, PhoneState.OffHook)
    .Permit(TriggerPhone.TakenOffHold, PhoneState.OnHook);

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
    CallDialed,
    HungUp,
    CallConnected,
    PlacedOnHook,
    TakenOffHold,
    LeftMessage
}


using Stateless;



var call = new StateMachine<PhoneState, TriggerPhone>
    (PhoneState.OffHook);

call.Configure(PhoneState.OffHook)
    .Permit(TriggerPhone.CallDialed, PhoneState.Connecting);

call.Configure(PhoneState.Connecting)
    .Permit(TriggerPhone.PlacedOnHook, PhoneState.OffHook)
    .Permit(TriggerPhone.CallConnected, PhoneState.Connected);

call.Configure(PhoneState.Connected)
    .Permit(TriggerPhone.LeftMessage, PhoneState.Connected)
    .Permit(TriggerPhone.PlacedOnHook, PhoneState.OffHook)
    .Permit(TriggerPhone.TakenOffHold, PhoneState.OnHook);

call.Fire(TriggerPhone.CallDialed);





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
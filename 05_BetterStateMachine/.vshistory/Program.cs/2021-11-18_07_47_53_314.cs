using Stateless;



var call = new StateMachine<PhoneState, TriggerPhone>
    (PhoneState.OffHook);

call.Configure(PhoneState.OffHook)
    .Permit(TriggerPhone.CallDialed, PhoneState.Connecting)
    .OnEntry(() => WriteState(call))
    .OnExit(() => Exit());


call.Configure(PhoneState.Connecting)
    .Permit(TriggerPhone.PlacedOnHook, PhoneState.OffHook)
    .Permit(TriggerPhone.CallConnected, PhoneState.Connected)
    .OnEntry(() => WriteState(call))
    .OnExit(() => Exit()); ;

call.Configure(PhoneState.Connected)
    .PermitReentry(TriggerPhone.LeftMessage)//, PhoneState.Connected
    .Permit(TriggerPhone.PlacedOnHook, PhoneState.OffHook)
    .Permit(TriggerPhone.TakenOffHold, PhoneState.OnHook)
    .Permit(TriggerPhone.EndThis, PhoneState.EndThis)
    .OnEntry(() => WriteState(call))
    .OnExit(() => Exit()); ;

call.Configure(PhoneState.EndThis);



IEnumerable<TriggerPhone> alltriggers = 
    Enum.GetValues(typeof(TriggerPhone))
    .Cast<TriggerPhone>();

while (call.PermittedTriggers.Count() != 0)
{
    Console.WriteLine("---- What Can You Do Next ----");
    foreach (TriggerPhone item in 
        call.PermittedTriggers)
    {
        Console.WriteLine($"{((int)item)} - {item} ");
    }
    int input = int.Parse(Console.ReadLine());

    TriggerPhone next = (TriggerPhone)input;

    call.Fire(next);

}






void WriteState(StateMachine<PhoneState, TriggerPhone> state)
{
    Console.WriteLine(state.State);


}

void Exit()
{
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("Change");
    Console.ResetColor();
}

public enum PhoneState
{
    OffHook,
    Connecting,
    Connected,
    OnHook,
    EndThis
}

public enum TriggerPhone
{
    CallDialed = 0,
    HungUp = 1,
    CallConnected = 2,
    PlacedOnHook = 3,
    TakenOffHold = 4,
    LeftMessage = 5 ,
    EndThis = 6,
}


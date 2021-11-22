
var beerMachine = new
    StateMachine<bool, BeerTrigger>(true);

System.Diagnostics.Stopwatch watch =
    System.Diagnostics.Stopwatch.StartNew();

beerMachine.Configure(false)
    .Permit(BeerTrigger.Fill, true)
    .Ignore(BeerTrigger.Drink);

beerMachine.Configure(true)
    .Permit(BeerTrigger.Drink, false)
    .Ignore(BeerTrigger.Fill)
    .OnEntry(() => watch = System.Diagnostics.Stopwatch.StartNew())
    .OnExit(() =>
    {
        watch.Stop();
        Console.WriteLine("Jak szybko pije");
        Console.WriteLine(watch.ElapsedMilliseconds);
    }
);








public enum BeerTrigger
{
    Drink,
    Fill
}
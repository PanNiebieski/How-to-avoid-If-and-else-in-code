
using Stateless;

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

beerMachine.Fire(BeerTrigger.Drink);
beerMachine.Fire(BeerTrigger.Fill);
beerMachine.Fire(BeerTrigger.Fill);
Thread.Sleep(3000);
beerMachine.Fire(BeerTrigger.Drink);
Console.Read();

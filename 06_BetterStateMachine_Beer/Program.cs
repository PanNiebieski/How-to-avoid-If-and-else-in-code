
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







//var beerMachine2 = new
//StateMachine<bool, BeerTrigger>(true);

//beerMachine2.Configure(false)
//    .Permit(BeerTrigger.Fill, true)
//    .OnEntry(transition =>
//    {
//        if (transition.IsReentry)
//            Console.WriteLine("Już wypiłeś piwo");
//        else
//            Console.WriteLine("Wypijam piwo");
//    })
//    .PermitReentry(BeerTrigger.Drink);

//beerMachine2.Configure(true)
//    .Permit(BeerTrigger.Drink, false)
//    .OnEntry(transition =>
//    {
//        if (transition.IsReentry)
//            Console.WriteLine("Już uzupełniłeś piwo");
//        else
//            Console.WriteLine("Wypełniam piwem");
//    })
//    .PermitReentry(BeerTrigger.Fill);

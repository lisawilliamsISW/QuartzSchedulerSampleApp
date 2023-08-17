// See https://aka.ms/new-console-template for more information

using Quartz;
using Quartz.Impl.Triggers;

DateTime expectedStaticDate = new DateTime(2023, 09, 01, 16, 0, 0, DateTimeKind.Utc);

DateTime finalWednesdayOfAugust = new DateTime(2023, 08, 30, 13, 0 , 0, DateTimeKind.Utc);

object EveryTwoMonthsCronExpression()
{
    //scheduled to run the first of the month, every 2 months at noon
    CronExpression schedule = new CronExpression("0 0 12 1 1/2 ? *");
    var nextFireTime = schedule.GetTimeAfter(DateTime.UtcNow);
    CronTriggerImpl cronTrigger = new CronTriggerImpl
    {
        CronExpression = schedule,
        Name = $"{nextFireTime}",
        StartTimeUtc = DateTime.UtcNow,
        MisfireInstruction = MisfireInstruction.CronTrigger.DoNothing,
    };
    ISet<ITrigger> triggers = new HashSet<ITrigger>() { cronTrigger };
    Console.WriteLine("Every two months on the first of the month starting now");
    Console.WriteLine($"NextFireTime: {nextFireTime}");
    Console.WriteLine($"ExpectedFireTime {expectedStaticDate} \n");
    return triggers;
}

object EveryThreeMonthsCronExpression()
{
    //scheduled to run every 3 months at noon
    CronExpression schedule = new CronExpression("0 0 12 1 1/3 ? *");
    var nextFireTime = schedule.GetTimeAfter(DateTime.UtcNow);
    CronTriggerImpl cronTrigger = new CronTriggerImpl
    {
        CronExpression = schedule,
        Name = $"{nextFireTime}",
        StartTimeUtc = DateTime.UtcNow,
        MisfireInstruction = MisfireInstruction.CronTrigger.DoNothing,
    };
    ISet<ITrigger> triggers = new HashSet<ITrigger>() { cronTrigger };
    Console.WriteLine("Every three months on the first of the month starting now");
    Console.WriteLine($"NextFireTime: {nextFireTime}");
    Console.WriteLine($"ExpectedFireTime {expectedStaticDate}\n");
    return triggers;
}

object FinalWednesdayEvery2Months()
{
    //last wednesday every 2 months at 9
    CronExpression schedule = new CronExpression("0 0 9 ? 1/2 4L");
    var nextFireTime = schedule.GetTimeAfter(DateTime.UtcNow);
    Console.WriteLine("Final Wednesday of the month");
    Console.WriteLine($"NextFireTime: {nextFireTime}");
    Console.WriteLine($"ExpectedFireTime {finalWednesdayOfAugust}\n");
    return schedule;
}

object FinalWednesdayEvery3Months()
{
    //last wednesday every 3 months at 9
    CronExpression schedule = new CronExpression("0 0 9 ? 1/3 4L");
    var nextFireTime = schedule.GetTimeAfter(DateTime.UtcNow);
    Console.WriteLine("Final Wednesday of the month");
    Console.WriteLine($"NextFireTime: {nextFireTime}");
    Console.WriteLine($"ExpectedFireTime {finalWednesdayOfAugust} \n");
    return schedule;
}

EveryTwoMonthsCronExpression();

EveryThreeMonthsCronExpression();

FinalWednesdayEvery2Months();

FinalWednesdayEvery3Months();

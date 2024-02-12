using Proto;

namespace KnutsenOgLudvigsen;

public class Ludvigsen : IActor
{
    public Task ReceiveAsync(
        IContext context)
    {
        if (context.Message is StartSangen start)
        {
            Console.WriteLine(
                $"{context.Actor}:\tHallo?");

            context.Send(
                context.Spawn(
                    Props.FromProducer(
                        () => new Knutsen()
                    )
                ),
                new Hallo(context.Self));
        }
        if (context.Message is Hallo hallo)
        {
            Console.WriteLine(
                $"{context.Actor}:\tHvordan står det til?");

            context.Send(
                hallo.fra,
                new HvordanStårDetTil(context.Self));
        }
        if (context.Message is HeiPåDeg hei)
        {
            Console.WriteLine(
                $"{context.Actor}:\tHei på deg!");

            context.Send(
                hei.fra,
                new HeiPåDeg(context.Self));
        }
        return Task.CompletedTask;
    }
}


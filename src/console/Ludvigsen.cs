using Proto;

namespace KnutsenOgLudvigsen;

public class Ludvigsen : IActor
{
    public Task ReceiveAsync(
        IContext context)
    {
        if (context.Message is StartSangen start)
        {
            Console.WriteLine("Hallo?");

            var props = Props.FromProducer(
                () => new Knutsen()
            );
            var knutsen = context
                .System
                .Root
                .Spawn(props);

            context.Send(
                knutsen,
                new Hallo(context.Self));
        }
        if (context.Message is Hallo hallo)
        {
            Console.WriteLine("Hvordan står det til?");

            context.Send(
                hallo.fra,
                new HvordanStårDetTil(context.Self));
        }
        if (context.Message is HeiPåDeg hei)
        {
            Console.WriteLine("Hei på deg!");

            context.Send(
                hei.fra,
                new HeiPåDeg(context.Self));
        }
        return Task.CompletedTask;
    }
}


using Proto;

namespace KnutsenOgLudvigsen;

public class Knutsen() : IActor
{
    public Task ReceiveAsync(
        IContext context
    )
    {
        if (context.Message is Hallo hallo)
        {
            Console.WriteLine("Hallo!");

            context.Send(
                hallo.fra,
                new Hallo(context.Self));
        }

        if (context.Message is HvordanStårDetTil stårTil)
        {
            Console.WriteLine("Bare bra!");

            context.Send(
                stårTil.fra,
                new HeiPåDeg(context.Self));
        }

        if (context.Message is HeiPåDeg)
        {
            Console.WriteLine("Hei på deg, Ludvigsen!");
        }

        return Task.CompletedTask;
    }
}


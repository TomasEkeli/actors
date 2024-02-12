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
            Console.WriteLine(
                $"{context.Actor}:\tHallo!");

            context.Send(
                hallo.fra,
                new Hallo(context.Self));
        }

        if (context.Message is HvordanStårDetTil stårTil)
        {
            Console.WriteLine(
                $"{context.Actor}:\tBare bra!");

            context.Send(
                stårTil.fra,
                new HeiPåDeg(context.Self));
        }

        if (context.Message is HeiPåDeg)
        {
            Console.WriteLine(
                $"{context.Actor}:\tHei på deg, Ludvigsen!");
        }

        return Task.CompletedTask;
    }
}


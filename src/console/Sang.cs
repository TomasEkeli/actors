using Proto;

public class Sang : IActor
{
    PID _knutsen;

    ActorSystem _system;

    public Task ReceiveAsync(
        IContext context
    )
    {
        Console.WriteLine("sang: got msg");
        if (context.Message is Started started)
        {
            _system = context.System;
            var knutsenP = Props.FromProducer(() => new Knutsen());
            _knutsen = _system.Root.Spawn(knutsenP);

            _system.Root.Send(_knutsen, new StartSangen());
        }
        if (context.Message is Hallo hallo && hallo.first)
        {
            Console.WriteLine("response");
        }

        return Task.CompletedTask;
    }
}
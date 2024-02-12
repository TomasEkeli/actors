using Proto;

namespace KnutsenOgLudvigsen;

public class Sang : IActor
{
    public Task ReceiveAsync(
        IContext context
    )
    {
        if (context.Message is Started started)
        {
            var system = context.System;

            system.Root.Send(
                target: system.Root.Spawn(
                    Props.FromProducer(() =>
                        new Ludvigsen()
                    )
                ),
                message: new StartSangen());
        }

        return Task.CompletedTask;
    }
}
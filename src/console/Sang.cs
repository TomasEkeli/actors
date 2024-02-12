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
            var knutsen = system
                .Root
                .Spawn(
                    Props
                    .FromProducer(() =>
                        new Ludvigsen()
                    )
                );

            system
                .Root
                .Send(
                    knutsen,
                    new StartSangen());
        }

        return Task.CompletedTask;
    }
}
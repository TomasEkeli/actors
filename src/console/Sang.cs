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
            context.Send(
                target: context.Spawn(
                    Props.FromProducer(() =>
                        new Ludvigsen()
                    )
                ),
                message: new StartSangen());
        }

        return Task.CompletedTask;
    }
}
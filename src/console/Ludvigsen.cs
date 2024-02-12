using Proto;

public class Ludvigsen() : IActor
{
    PID? _noen;

    public Task ReceiveAsync(
        IContext context
    )
    {
        if (context.Message is Hallo hallo)
        {
            Console.WriteLine("Hallo!");

            _noen = context.Sender;
            context.Send(_noen, new Hallo(false));
        }

        return Task.CompletedTask;
    }
}


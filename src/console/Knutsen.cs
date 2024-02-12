using Proto;

public class Knutsen : IActor
{
    PID _ludvigsen;

    public Task ReceiveAsync(
        IContext context)
    {
        if (context.Message is StartSangen start)
        {
            Console.WriteLine("Hallo?");

            var props = Props.FromProducer(
                () => new Ludvigsen()
            );
            _ludvigsen = context.System.Root.Spawn(props);

            context.Send(_ludvigsen, new Hallo(true));
        }
        if (context.Message is Hallo hallo)
        {
            Console.WriteLine("Hvordan står det til?");

        }
        return Task.CompletedTask;
    }
}


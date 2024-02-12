using Proto;
using KnutsenOgLudvigsen;

var system = new ActorSystem();

var sang = system
    .Root
    .Spawn(
        Props.FromProducer(() => new Sang())
    );

// start sangen
system.Root.Send(sang, new StartSangen());

// om vi ikke venter så avslutter dotnet før vi får sunget
await Task.Delay(20);

using Proto;

var system = new ActorSystem();

var sangP = Props.FromProducer(() => new Sang());
var sang = system.Root.Spawn(sangP);

system.Root.Send(sang, new StartSangen());

await Task.Delay(1000);

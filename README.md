# ServiceBusTopicsDemo

This is a slightly modified version of the MS Docs ServiceBus Topics guide. The primary difference is the use of `ServiceBusConnectionStringBuilder` to provide `TransportType.AmqpWebSockets` avoiding firewall issues it's possible to encounter on secure networks.

## Setup
From ServiceBus settings "Shared access policies" select a policy and from one of the connection strings take the `Endpoint`, `SharedAccessKeyName` and `SharedAccessKey` from the connection string:
```
Endpoint={THIS_ENDPOINT};SharedAccessKeyName={THIS_KEY_NAME};SharedAccessKey={THIS_KEY}
```
and add them along with the target topic and subscription (for Receive) name to the variables at the top of `Program.cs` => `Main()`.

Make sure NuGet packages have restored before attempting to run.

## Running
Run the app locally from Visual Studio 2017 and enter 1 to add items to the queue, or run the app and enter 2 to read the items from the queue.
using Azure.Messaging.ServiceBus;

const string connectionString =
    "Endpoint=sb://localhost/;" +
    "SharedAccessKeyName=RootManageSharedAccessKey;" +
    "SharedAccessKey=SAS_KEY_VALUE;" +
    "UseDevelopmentEmulator=true;";


const string topic = "waiting-dni";    


await using var client = new ServiceBusClient(connectionString);

ServiceBusSender sender = client.CreateSender(topic);

var message = new 
{
    Dni = "12345678B",
    CustomerId = 1234,
    Timestamp = DateTime.UtcNow
};

var json = System.Text.Json.JsonSerializer.Serialize(message);

var serviceBusMessage = new ServiceBusMessage(json)
{
    ContentType = "application/json",
    Subject = "WaitingDni"
};

await sender.SendMessageAsync(serviceBusMessage);

Console.WriteLine($"Evento enviado a '{topic}'");
Console.WriteLine(json);
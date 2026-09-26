using Azure.Messaging.ServiceBus;

const string connectionString =
    "Endpoint=sb://localhost;" +
    "SharedAccessKeyName=RootManageSharedAccessKey;" +
    "SharedAccessKey=SAS_KEY_VALUE;" +
    "UseDevelopmentEmulator=true";

const string queueName = "orders";

await using var client = new ServiceBusClient(connectionString);

ServiceBusSender sender = client.CreateSender(queueName);

var message = new ServiceBusMessage("""
{
    "eventType": "OrderCreated",
    "orderId": 123,
    "customerId": 456,
    "amount": 125.50,
    "detination": "Argentina"
}
""");

message.ContentType = "application/json";

await sender.SendMessageAsync(message);

Console.WriteLine("Evento enviado correctamente.");
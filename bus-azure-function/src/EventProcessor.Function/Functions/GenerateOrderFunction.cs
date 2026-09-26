using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace EventProcessor.Function.Functions;

public class GenerateOrderFunction
{
    private readonly ILogger<GenerateOrderFunction> _logger;
    private readonly ServiceBusClient _serviceBusClient;

    public GenerateOrderFunction(ILogger<GenerateOrderFunction> logger)
    {
        _logger = logger;

        var connectionString =
            Environment.GetEnvironmentVariable("ServiceBusConnection")
            ?? throw new InvalidOperationException(
                "ServiceBusConnection no está configurada.");

        _serviceBusClient = new ServiceBusClient(connectionString);
    }

    [Function("GenerateOrder")]
    public async Task Run([TimerTrigger("*/30 * * * * *")] TimerInfo timer)
    {
        var order = new
        {
            EventType = "OrderCreated",
            OrderId = Random.Shared.Next(1, 100000),
            CustomerId = Random.Shared.Next(1, 1000),
            Amount = Math.Round(Random.Shared.NextDouble() * 500, 2),
            CreatedAt = DateTime.UtcNow
        };

        var json = JsonSerializer.Serialize(order);

        await using var sender =
            _serviceBusClient.CreateSender("orders");

        var message = new ServiceBusMessage(json)
        {
            ContentType = "application/json"
        };

        await sender.SendMessageAsync(message);

        _logger.LogInformation("Evento enviado a Service Bus: {Message}", json);
    }
}
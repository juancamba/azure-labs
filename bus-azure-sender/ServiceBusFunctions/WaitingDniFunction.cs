using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ServiceBusFunctions;

public class WaitingDniFunction
{
    private readonly ILogger<WaitingDniFunction> _logger;

    public WaitingDniFunction(ILogger<WaitingDniFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(WaitingDniFunction))]
    public async Task Run(
        [ServiceBusTrigger("waiting-dni", "waiting-dni-sub", Connection = "ServiceBusConnection")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        _logger.LogInformation("Message ID: {id}", message.MessageId);
        _logger.LogInformation("Message Body: {body}", message.Body);
        _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
        await messageActions.CompleteMessageAsync(message);
    }
}
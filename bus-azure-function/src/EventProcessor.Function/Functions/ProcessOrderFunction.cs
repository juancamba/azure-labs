using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EventProcessor.Function.Functions;

public class ProcessOrderFunction
{
    private readonly ILogger<ProcessOrderFunction> _logger;

    public ProcessOrderFunction(ILogger<ProcessOrderFunction> logger)
    {
        _logger = logger;
    }

    [Function("ProcessOrder")]
    public void Run( [ServiceBusTrigger("orders",  Connection = "ServiceBusConnection")] string message)
    {
        _logger.LogInformation( "Evento recibido: {Message}", message);
    }
}
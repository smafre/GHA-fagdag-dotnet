using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Fagdag.FunctionApp;

public class SumFunction
{
    private readonly ILogger<SumFunction> _logger;

    public SumFunction(ILogger<SumFunction> logger)
    {
        _logger = logger;
    }

    // Denne function appen tar inn to tall via Url GET/Query parameter, og returnerer en tekst, med sum av tallene.

    [Function("SumAvToTall")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function mottok en request.");

        string? num1String = req.Query["a"];
        string? num2String = req.Query["b"];
        if (!int.TryParse(num1String, out int num1) || !int.TryParse(num2String, out int num2))
        {
            return new BadRequestObjectResult("Oppgi to tall, som GET parameter: 'a' og 'b'.");
        }

        int sum = Kalkulator.Sum(num1, num2);

        return new OkObjectResult($"Summen av {num1} og {num2} er: {sum}.");
    }
}
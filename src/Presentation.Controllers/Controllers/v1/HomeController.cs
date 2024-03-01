using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Controllers.v1;

public class HomeController : BaseController
{
    private readonly ICustomLogger _logger;

    public HomeController(IMediator mediator, ICustomLogger logger) : base(mediator)
    {
        _logger = logger;
    }

    [HttpGet]
    public string SayInfo()
    {
        _logger.LoggerError("This is error log from HomeController");
        _logger.LoggerWarn("This is warn log from HomeController");
        _logger.LoggerDebug("This is debug log from HomeController");
        _logger.LogInfo("This is info log from HomeController");

        return "Hello from Home controller";
    }
}
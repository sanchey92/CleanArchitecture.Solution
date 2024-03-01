using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Controllers.v1;

/// <summary>
/// Abstract base class for API controllers in the ASP.NET Core Web API.
/// Provides versioning support and common dependencies like MediatR for handling requests.
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator Mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator for sending requests to application handlers.</param>
    protected BaseController(IMediator mediator) => Mediator = mediator;
}

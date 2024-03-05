using System.Text.Json;
using Application.RequestFeatures;
using Domain.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Controllers.ActionFilters;

/// <summary>
/// Action filter to add pagination header to the response based on the result being a PagedList.
/// </summary>
/// <typeparam name="T">Type of items in the PagedList.</typeparam>
public class AddPaginationHeaderAttribute<T> : ActionFilterAttribute where T : BaseEntity
{
    /// <summary>
    /// Called after the action executes, adding the pagination header if the result is a PagedList.
    /// </summary>
    /// <param name="context">The context for the action filter.</param>
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult objectResult && objectResult.Value is PagedList<T> pagedList)
        {
            var metaData = JsonSerializer.Serialize(pagedList.MetaData);
            context.HttpContext.Response.Headers.Append("X-Pagination", metaData);
        }
    }
}
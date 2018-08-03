using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace AuctionHouse.WebApi.Security
{
    public class CustomAuthorizeFilter : IAsyncAuthorizationFilter
    {
        public AuthorizationPolicy Policy { get; }

        public CustomAuthorizeFilter(AuthorizationPolicy policy)
        {
            Policy = policy ?? throw new ArgumentNullException(nameof(policy));
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }

            var policyEvaluator = context.HttpContext.RequestServices.GetRequiredService<IPolicyEvaluator>();
            var authenticationResult = await policyEvaluator.AuthenticateAsync(Policy, context.HttpContext);
            var authorizationResult =
                await policyEvaluator.AuthorizeAsync(Policy, authenticationResult, context.HttpContext, context);

            if (authorizationResult.Challenged)
            {
                context.Result = new CustomUnauthorizedResult("Authorization failed.");
            }
            else if (authorizationResult.Forbidden)
            {
                context.Result = new ForbidResult(Policy.AuthenticationSchemes.ToArray());
            }
        }
    }

    public class CustomUnauthorizedResult : JsonResult
    {
        public CustomUnauthorizedResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status401Unauthorized;
        }

        public CustomUnauthorizedResult(object value, JsonSerializerSettings serializerSettings) : base(value, serializerSettings)
        {
            StatusCode = StatusCodes.Status401Unauthorized;
        }
    }
}
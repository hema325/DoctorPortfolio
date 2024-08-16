using Ibrahim.DoctorPortfolio.Enums;
using Ibrahim.DoctorPortfolio.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Ibrahim.DoctorPortfolio.Filters
{
    public class CacheAttribute: ActionFilterAttribute
    {
        private readonly CachePeriods _period;

        public CacheAttribute(CachePeriods period = CachePeriods.Medium)
        {
            _period = period;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheSettings = context.HttpContext.RequestServices
                .GetRequiredService<IOptions<CacheSettings>>().Value;

            if (cacheSettings.IsEnabled)
            {
                var cache = context.HttpContext.RequestServices
                    .GetRequiredService<IMemoryCache>();

                var cacheKey = context.HttpContext.Request.Path +
                    context.HttpContext.Request.QueryString + 
                    "-Culture-" +
                    context.HttpContext.Request.Headers["Culture"];

                var cachedResult = cache.Get(cacheKey);

                if (cachedResult != null)
                    context.Result = new OkObjectResult(cachedResult);
                else
                {
                    var actionResult = await next();

                    if (actionResult.Result is OkObjectResult okObjResult)
                        cache.Set(cacheKey, okObjResult.Value, TimeSpan.FromSeconds((double)_period));
                }
            }
            else
                await next();
        }
    }
}

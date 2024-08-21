
using System.Globalization;

namespace Ibrahim.DoctorPortfolio.Middlewares
{
    public class RequestCultureDetector : IMiddleware
    {
        private const string LangHeader = "Accept-Language";

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var lang = context.Request.Headers[LangHeader];

            CultureInfo.CurrentCulture = new CultureInfo("en");

            if (lang == "ar")
                CultureInfo.CurrentCulture = new CultureInfo("ar");

            await next(context);
        }
    }
}

using AdvanceDotNet.Utlis.Enums;
using AdvanceDotNet.Utlis;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace AdvanceDotNet.RepositoryPattern.Handlers
{
    public class GlobalExceptionHandler: IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var result = Result<object>.Fail(exception);
            httpContext.Response.StatusCode = (int)EnumHttpStatusCode.Success;
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(result), cancellationToken);
            

            return true;
        }
    }
}

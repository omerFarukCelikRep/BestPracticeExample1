using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Api.Extensions
{
    public static class HealtCheckConfigureExtension
    {
        public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/health", new HealthCheckOptions()
            {
                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("OK");
                }
            });

            return app;
        }
    }
}

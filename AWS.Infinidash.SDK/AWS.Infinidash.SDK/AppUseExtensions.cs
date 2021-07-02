using Microsoft.AspNetCore.Builder;

namespace Amazon.Infinidash.SDK
{
    public static class AppUseExtensions
    {
        public static IApplicationBuilder UseInfinidash(this IApplicationBuilder app)
        {
            var sdk = new InfinidashContext();
            sdk.Initilize();
            return app;
        }
    }
}
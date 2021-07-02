using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Amazon.Infinidash.SDK
{
    public class InfinidashContext
    {
        // https://www.youtube.com/watch?v=x31tDT-4fQw
        static InfinidashContext()
        {
            OpenBrowser("https://www.youtube.com/watch?v=x31tDT-4fQw");
        }

        public static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }

    public static class AppUseExtensions
    {
        public static IApplicationBuilder UseHttpsRedirection(this IApplicationBuilder app)
        {

        }
    }
}

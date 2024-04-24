using System.Diagnostics;

namespace ObsWebUI.MyMiddlewares
{
    public class PerformanceLoggerMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            Stopwatch sw = Stopwatch.StartNew();

            await next(context);

            sw.Stop();

            var userIp = context.Connection.RemoteIpAddress;

            var logDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            var logFilePath = Path.Combine(logDirectoryPath, "PerformanceLogs.txt");

            if (!Directory.Exists(logDirectoryPath))
            {
                Directory.CreateDirectory(logDirectoryPath);
            }

            var log = $"{DateTime.Now}, Ip: {userIp}, ";

            log += $"ElapsedTimeMS: {sw.Elapsed.TotalMilliseconds}, ";

            log += $"QueryString: {context.Request.QueryString.Value}, ";

            log += $"Url: {context.Request.Path}\n";

            
            await File.AppendAllTextAsync(logFilePath, log);

        }
    }
}

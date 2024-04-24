namespace ObsWebUI.MyMiddlewares
{
    public class IpLoggerMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var userIp = context.Connection.RemoteIpAddress;

            var logDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

            var logFilePath = Path.Combine(logDirectoryPath, "IpLogs.txt");

            if (!Directory.Exists(logDirectoryPath))
            {
                Directory.CreateDirectory(logDirectoryPath);
            }

            var log = $"{DateTime.Now}, Ip: {userIp}\n";

            await File.AppendAllTextAsync(logFilePath, log);

            await next(context);
        }
    }
}

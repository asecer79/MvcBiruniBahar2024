namespace ObsWebUI.MyMiddlewares
{
    public class ErrorLoggerMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await next(context);
            }
            catch (Exception e)
            {

                var userIp = context.Connection.RemoteIpAddress;
                var logDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
                var logFilePath = Path.Combine(logDirectoryPath, "ErrorLogs.txt");

                if (!Directory.Exists(logDirectoryPath))
                {
                    Directory.CreateDirectory(logDirectoryPath);
                }

                var log = $"{DateTime.Now}, Ip: {userIp}, ";

                log += $"QueryString: {context.Request.QueryString.Value}, ";

                log += $"Url: {context.Request.Path}, ";

                log += $"Exception: {e.StackTrace},\n";

                await File.AppendAllTextAsync(logFilePath, log);

               await context.Response.WriteAsync(e.Message);
            }
        }
    }
}

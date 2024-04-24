namespace ObsWebUI.MyMiddlewares
{
    public class AccessLoggerMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var userIp = context.Connection.RemoteIpAddress;

            var logDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            var logFilePath = Path.Combine(logDirectoryPath, "AccessLogs.txt");

            if (!Directory.Exists(logDirectoryPath))
            {
                Directory.CreateDirectory(logDirectoryPath);
            }

            var log = $"{DateTime.Now}, Ip: {userIp}, ";

            if (context.Request.Method=="POST")
            {
                log += "FormData: ";
                foreach (var key in context.Request.Form.Keys.Where(p=>p!= "__RequestVerificationToken"))
                {
                    log += $"Key: {key}, Value: {context.Request.Form[key]}, ";
                }
            }

            log += $"QueryString: {context.Request.QueryString.Value}, ";

            log += $"Url: {context.Request.Path}\n";

            
            await File.AppendAllTextAsync(logFilePath, log);

            await next(context);
        }
    }
}

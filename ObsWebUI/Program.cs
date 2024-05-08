using Business.AuthorizationServices;
using Business.AuthorizationServices.Abstract;
using Business.AuthorizationServices.Concrete;
using Business.CommonServices.ICommonUserInterfaces;
using Business.Services.Obs.Abstract;
using Business.Services.Obs.Concrete;
using Caching.Abstract;
using Caching.Concrete;
using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using DataAccess.ObsDbContext.Ef.Dal.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using ObsWebUI.MyMiddlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IDepartmentDal, DepartmentDal>();
builder.Services.AddSingleton<IFacultyDal, FacultyDal>();
builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
builder.Services.AddSingleton<IFacultyService, FacultyService>();

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IUserDal, UserDal>();
builder.Services.AddSingleton<IOperationClaimDal, OperationClaimDal>();
builder.Services.AddSingleton<IOperationClaimService, OperationClaimService>();
builder.Services.AddSingleton<IUserOperationClaimDal, UserOperationClaimDal>();
builder.Services.AddSingleton<IUserOperationClaimService, UserOperationClaimService>();
builder.Services.AddSingleton<IAuthService, AuthService>();

//builder.Services.AddSingleton<ICacheProvider, MemoryCacheProvider>();
builder.Services.AddSingleton<ICacheProvider, RedisCacheProvider>();


var cookieOptions = builder.Configuration.GetSection("CookieAuthOption").Get<CookieAuthOption>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.AccessDeniedPath = cookieOptions.AccessDeniedPath;
    options.Cookie.Name = cookieOptions.Name;
    options.LoginPath = cookieOptions.LoginPath;
    options.LogoutPath = cookieOptions.LogOutPath;
    options.SlidingExpiration = cookieOptions.SlidingExpiration;
    options.ExpireTimeSpan = TimeSpan.FromSeconds(cookieOptions.TimeOut);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




//inline middleware

//app.Use(async (context, next) =>
//{
//    Debug.Write("Request Process 1\n");
//    //request
//    await next();
//    //response
//    Debug.Write("Response Process 1\n");
//});

//app.Use(async (context, next) =>
//{
//    Debug.Write("Request Process 2\n");
//    //request
//    await next();
//    //response
//    Debug.Write("Response Process 2\n");
//});

//app.Use(async (context, next) =>
//{
//    Debug.Write("Request Process 3\n");
//    //request
//    await next();
//    //response
//    Debug.Write("Response Process 3\n");
//});

//app.UseMiddleware<IpLoggerMiddleware>();

app.UseMiddleware<AccessLoggerMiddleware>();

app.UseMiddleware<ErrorLoggerMiddleware>();

app.UseMiddleware<PerformanceLoggerMiddleware>();

//app.UseWhen(context => context.Request.Method.Equals("POST"), appBuilder =>
//{
//    app.UseMiddleware<ErrorLoggerMiddleware>();
//});

//app.MapWhen(context => context.Request.Method.Equals("POST"), appBuilder =>
//{
//    app.UseMiddleware<ErrorLoggerMiddleware>();
//});

//app.Map("/Faculties", appBuilder =>
//{
//    app.UseMiddleware<ErrorLoggerMiddleware>();
//});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();





app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();

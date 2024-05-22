using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.ObsDependencyResolver;
using Business.Services.Obs.Abstract;
using Caching.Abstract;
using Caching.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Client.Internal;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddSingleton<ICacheProvider, MemoryCacheProvider>();
builder.Services.AddSingleton<ICacheProvider, RedisCacheProvider>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew =TimeSpan.Zero,
        
    };

});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin",policy=>policy.RequireRole("Admin"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
});




builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new ObsDependencyResolver());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

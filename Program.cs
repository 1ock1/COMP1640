using COMP1640.Repositories;
using COMP1640.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF1cXmhIfEx1RHxQdld5ZFRHallYTnNWUj0eQnxTdEFjWn9fcHdXQWBcUkFzVw==");
var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "hehe";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(

    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Issue Here",
            ValidAudience = "Audiencce Here",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my secret key a ah")),
            ClockSkew = TimeSpan.FromSeconds(60)
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("Token-Expired", "true");
                }
                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
RepositoryRegistration.AddRepositoryRegistration(builder.Services);
builder.Services.AddDbContext<DataContext>();
//foreach (var service in builder.Services)
//{
//    Console.WriteLine($"Service Type: {service.ServiceType}, Lifetime: {service.Lifetime}");
//}
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000/")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .SetIsOriginAllowed((host) => true)
                                                  .AllowCredentials();
                      });
});
var app = builder.Build();

// Only for stg environment
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(MyAllowSpecificOrigins);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

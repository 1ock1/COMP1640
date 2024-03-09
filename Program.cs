using COMP1640.Repositories;
using COMP1640.Utils;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF1cXmhIfEx1RHxQdld5ZFRHallYTnNWUj0eQnxTdEFjWn9fcHdXQWBcUkFzVw==");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

RepositoryRegistration.AddRepositoryRegistration(builder.Services);
builder.Services.AddDbContext<DataContext>();
foreach (var service in builder.Services)
{
    Console.WriteLine($"Service Type: {service.ServiceType}, Lifetime: {service.Lifetime}");
}
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "hehe",
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
app.UseCors("hehe");
// Only for stg
//app.UseSwagger();
//app.UseSwaggerUI();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

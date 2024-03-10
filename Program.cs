using COMP1640.Repositories;
using COMP1640.Utils;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "hehe";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();

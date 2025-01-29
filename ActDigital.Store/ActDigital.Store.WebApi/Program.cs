using System.Reflection;
using ActDigital.Store.Sales.Infrastructure;
using ActDigital.Store.WebApi.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddMvcCore();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.RegisterServices();
builder.Services.AddGrpc();
builder.Services.AddEventStoreClient(new Uri(builder.Configuration["ConnectionStrings:EventStoreConnection"]));

var conn = builder.Configuration["ConnectionStrings:DefaultConnection"]; 
builder.Services.AddDbContext<SalesContext>(options =>
    options.UseSqlServer(conn));

builder.Services.AddScoped<DbContext, SalesContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});
app.UseHttpsRedirection();

app.Run();
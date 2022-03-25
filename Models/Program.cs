


using Microsoft.Extensions.Options;
using System.Web.Http;
var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.Configure<StoreApi.DB.StoreDatabaseSettings>(builder.Configuration.GetSection(nameof(StoreApi.DB.StoreDatabaseSettings)));
builder.Services.AddSingleton<StoreApi.DB.IStoreDatabaseSettings>(sp=>sp.GetRequiredService<IOptions<StoreApi.DB.StoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<StoreApi.Services.Concreate.StoreService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

             

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

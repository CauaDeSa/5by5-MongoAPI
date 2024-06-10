using _5by5_MongoAPI.Services;
using _5by5_MongoAPI.Utils;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<MongoAPIDataBaseSettings>(
               builder.Configuration.GetSection(nameof(MongoAPIDataBaseSettings)));

builder.Services.AddSingleton<IMongoAPIDataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<MongoAPIDataBaseSettings>>().Value);

builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<AddressService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
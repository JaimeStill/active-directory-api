using System.Text.Json;
using System.Text.Json.Serialization;
using DomainTools.Services;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DomainToolsService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();

app.MapControllers();

app.Run();
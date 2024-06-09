using Moresand_DevAssessment;
using Moresand_DevAssessment.Interfaces;
using Moresand_DevAssessment.ImageOperations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(Constants.AppSettingsFileName);

//Injected the dependecies for different classes
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddTransient<IImageOperation, ResizeOperation>();
builder.Services.AddTransient<IImageOperation, BlurOperation>();
builder.Services.AddTransient<IImageOperation, GreyScaleOperation>();
builder.Services.AddTransient<IPlugingsManager, PluginsManager>();

//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.Run();
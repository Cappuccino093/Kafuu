using Kafuu.Api.Authentication;
using Microsoft.AspNetCore.Authentication;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
	for (int i = 0; i < Kafuu.Core.Kafuu.JsonSerializerOptions.Converters.Count; i++)
		options.JsonSerializerOptions.Converters.Add(Kafuu.Core.Kafuu.JsonSerializerOptions.Converters[i]);
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication()
	.AddScheme<AuthenticationSchemeOptions, SignatureHandler>("DiscordSignature", "Discord Signature Authentication", options => { });

builder.Logging.AddConsole();

builder.Logging.AddDebug();

builder.Logging.AddAzureWebAppDiagnostics();

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

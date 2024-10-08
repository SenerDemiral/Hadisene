using Blazored.Modal;
using Blazored.Toast;
using Hadisene.Components;
using Hadisene.Lib;
using SixLabors.ImageSharp.Web.DependencyInjection;
//using StackExchange.Redis;
using System.Globalization;

CultureInfo culture;
culture = CultureInfo.CreateSpecificCulture("tr-TR");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;
Thread.CurrentThread.CurrentCulture = culture;
Thread.CurrentThread.CurrentUICulture = culture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Configuration.AddJsonFile("C:\\AspNetConfig\\Hadisene.json",
					   optional: false,
					   reloadOnChange: true);

//builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost"));
//builder.Services.AddScoped<PubSubService>();

builder.Services.AddImageSharp();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();

builder.Services.AddSingleton<IDbCon, DbCon>();

builder.Services.AddSingleton<NotifierService>();
builder.Services.AddScoped<AppState>();

builder.Services.AddHostedService<TimedHostedService>();

//Deneme
builder.Services.AddCascadingValue(s => CascadingValueSource.CreateNotifying(new User()));
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	//app.UseHsts();
	//app.UseResponseCompression();
	Console.WriteLine("not Development");
}

//app.UseHttpsRedirection();

app.UseImageSharp();

app.UseAntiforgery();

//app.UseStaticFiles();
app.MapStaticAssets();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

//	.AddInteractiveServerRenderMode(o => o.ContentSecurityFrameAncestorsPolicy = "'none'");
//.AddInteractiveServerRenderMode(o => o.DisableWebSocketCompression = true);
//	.AddInteractiveServerRenderMode(o => o.ConfigureWebSocketOptions = null);

// LanngVersion deneme System.Console.WriteLine((int)'\e');

app.Run();

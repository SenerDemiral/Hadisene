using Blazored.Modal;
using Hadisene.Components;
using Hadisene.Lib;
using SixLabors.ImageSharp.Web.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Configuration.AddJsonFile("C:\\AspNetConfig\\YapHaydi.json",
                       optional: false,
                       reloadOnChange: true);
builder.Services.AddImageSharp();
builder.Services.AddBlazoredModal();

builder.Services.AddSingleton<IDbCon, DbCon>();
builder.Services.AddSingleton<NotifierService>();
builder.Services.AddScoped<AppState>();

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

app.UseHttpsRedirection();

app.UseImageSharp();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode(o => o.ContentSecurityFrameAncestorsPolicy = "'none'");

//.AddInteractiveServerRenderMode(o => o.DisableWebSocketCompression = true);
//	.AddInteractiveServerRenderMode(o => o.ConfigureWebSocketOptions = null);

// LanngVersion deneme System.Console.WriteLine((int)'\e');

app.Run();

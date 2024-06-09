using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraApp.Components;
using MinhaPrimeiraApp.Components.Cascading;
using MinhaPrimeiraApp.Components.DI;
using MinhaPrimeiraApp.Components.Roteamento.Users;
using MinhaPrimeiraApp.Data;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//builder.Services.AddCascadingValue(sp =>
//{
//    var StyleContext = new StyleContext { BackgroundColor = "#ADD8E6" };
//    var source = new CascadingValueSource<StyleContext>(StyleContext, isFixed: false);
//    return source;
//});

builder.Services.AddCascadingValue(sp =>
    CascadingValueSource.CreateNotifying(new StyleContext()));

builder.Services.AddDbContext<PrimeiraAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PrimeiraAppContext")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithRedirects("/erro/{0}");

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MinhaPrimeiraApp.Client._Imports).Assembly);

app.Run();


public static class CascadingValueSource
{
    public static CascadingValueSource<T> CreateNotifying<T>(T value, bool isFixed = false) where T : INotifyPropertyChanged
    {
        var source = new CascadingValueSource<T>(value, isFixed);

        value.PropertyChanged += (sender, args) => source.NotifyChangedAsync();

        return source;
    }
}
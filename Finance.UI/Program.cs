using Finance.UI;
using Finance.UI.Extentions;
using Finance.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiConfiguration>(
    builder.Configuration.GetSection(ApiConfiguration.Configuration));

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<FinanceWebApiService>();

builder.Services.AddServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

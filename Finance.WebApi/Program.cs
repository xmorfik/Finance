using Finance.WebApi.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer(builder.Configuration);
builder.Services.AddRepositoryServices();
builder.Services.AddAppServices();
builder.Services.AddApis();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseStatusCodePages();

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<FinanceDbContext>();
//    context.Database.EnsureCreated();
//}

var apis = app.Services.GetServices<IApi>();

app.MapGet("/", () => Results.Ok());
app.MapGet("/api/v1", () => Results.Ok());

foreach (var api in apis)
{
    api.Register(app);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
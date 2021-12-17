using DataStructure1.Infra.DataAccess;
using DataStructure1.Infra.MongoDB.DataAccess;
using DataStructure1.Infra.SqlServer.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DataAccess layer
var SqlServerEnabled = builder.Configuration["SqlServerEnabled"];
var MongoEnabled = builder.Configuration["MongoDBEnabled"];
if (SqlServerEnabled != null && SqlServerEnabled == "true")
{
    builder.Services.AddSingleton<IDataAccess, SqlDataAccess>();
    builder.Services.AddModelDataServices("DataStructure1.Infra.SqlServer");
}
else if (MongoEnabled != null && MongoEnabled == "true")
{
    builder.Services.AddSingleton<IDataAccess, MongoDataAccess>();
    builder.Services.AddModelDataServices("DataStructure1.Infra.MongoDB");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

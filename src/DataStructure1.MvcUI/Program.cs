using DataStructure1.Core.ModelData;
using DataStructure1.Infra.DataAccess;
using DataStructure1.Infra.SqlServer.DataAccess;
using DataStructure1.Infra.SqlServer.ModelData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DataAccess layer
var SqlServerEnabled = builder.Configuration["SqlServerEnabled"];
if (SqlServerEnabled != null && SqlServerEnabled == "true")
    builder.Services.AddSingleton<IDataAccess, SqlDataAccess>();

// Data Models
builder.Services.AddSingleton<IEmployeeModelData, EmployeeModelData>();

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

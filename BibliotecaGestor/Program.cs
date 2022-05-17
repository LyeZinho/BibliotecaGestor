using BibliotecaGestor.Models.Database;




MySqlConn conn = new MySqlConn();
DapperDb dapper = new DapperDb().SetConection(conn.Conection());

dynamic data = dapper.Query("select_all_books");

foreach (var item in data)
{
    Console.WriteLine(item);
}



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

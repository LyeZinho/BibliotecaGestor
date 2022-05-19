using BibliotecaGestor.Models.Database;
using BibliotecaGestor.Models;

MySqlConector conn = new MySqlConector();
database db = new database(
    new WithdrawData(conn.Conection())
);
db.Update(new {
    Idwithdraw = 6,
    IdUser = 2,
    IdBook = 11,
    Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
});


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

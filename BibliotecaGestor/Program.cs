using BibliotecaGestor.Models.Database;




MySqlConector conector = new MySqlConector();
BookData bookData = new BookData(conector.Conection());
dynamic data = bookData.Get(1);

Console.WriteLine(data.GetTitle());

//foreach(var item in data)
//{
//    Console.WriteLine(item.GetAuthor());
//}


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

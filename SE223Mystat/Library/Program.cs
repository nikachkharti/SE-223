using Library.Configuration;
using Library.Data;
using Microsoft.EntityFrameworkCore;


//TODO 1. ბიბლიოთეკას ჰყავს თანამშრომლები შექმენით თანამშრომლის აღმნიშვნელი შესაბამისი ტიპი Employee შემდეგი პარამეტრებით:
//სახელი
//გვარი
//პირადი ნომერი
//ელ ფოსტა
//ტელეფონის ნომერი
//2. შექმენით ბაზაში ამ მოდელის შესაბამისი ცხრილი და შეავსეთ იგი სატესტო მონაცემებით
//3.ააწყვეთ ფუნქციონალი რომელიც პასუხსმგებელი იქნება თანამშრომლების მენეჯმენტზე

//ყველაფერი ეს შეასრულეთ Entity Framework ის გამოყენებით.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

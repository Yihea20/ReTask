using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReTask.AuthoManger;
using ReTask.Confgurations;
using ReTask.Data;
using ReTask.IRepository;
using ReTask.Models;
using ReTask.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ReTaskDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));
builder.Services.AddAuthentication();
builder.Services.AddIdentityCore<User>(q=>q.User.RequireUniqueEmail=true)
    .AddEntityFrameworkStores<ReTaskDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddRazorPages();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());
});
builder.Services.AddAutoMapper(typeof(MapperInitilizer));

//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthoManager, AuthoManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

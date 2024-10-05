using DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using BusinessLogicLayer.Services;
using Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register db contect
builder.Services.AddScoped(provider =>
    new DatabaseContext(builder.Configuration.GetConnectionString("DefaultConnection")!));


// Register services
builder.Services.AddScoped<IUserService, UserService>();

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register util
builder.Services.AddScoped<IEncryption, Sha256Encryption>();
builder.Services.AddScoped<IFileUploader, FileUploader>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
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

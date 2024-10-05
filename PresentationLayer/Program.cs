using BusinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using Utils;

var builder = WebApplication.CreateBuilder(args);

//Register db contect
builder.Services.AddTransient(provider => 
    new DatabaseContext(builder.Configuration.GetConnectionString("DefaultConnection")));


// Register services
builder.Services.AddScoped<IUserService, UserService>();

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register util
builder.Services.AddScoped<IEncryption, Sha256Encryption>();
builder.Services.AddScoped<IFileUploader, FileUploader>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

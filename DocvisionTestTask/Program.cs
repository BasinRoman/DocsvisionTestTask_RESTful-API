using Business.Implementations;
using Business.Interfaces;
using DocvisionTestTask.DAL;
using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // ???? ? ???? ????? ????????? ? appsettings.json

    // Add services to the container.
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.LogTo(Console.WriteLine);
        options.UseSqlServer(connectionString);
    });

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // DI repository
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
    builder.Services.AddScoped<IInBoxRepository, InBoxRepository>();

    // DI services
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IProfileService, ProfileService>();
    builder.Services.AddScoped<IEmailService, EmailService>();

    var app = builder.Build();

    // ??
    using var scope = app.Services.CreateScope();
    ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated(); // ??? ???????????? ???????? ?????? ? ????????? ????????????? ?? ? ?????????? ???????????.

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception exception)
{

    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}


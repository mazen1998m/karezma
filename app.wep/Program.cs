using App.Data.EFCore;
using App.web.InjectionService;
using App.web.JwtServices;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureJwt(builder.Configuration);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoScoped();
builder.Services.AutoInjectedServices();
builder.Services.ConfigureValidator();

builder.Services.AddEfDbContext<EfDbContext>(builder);
builder.Services.ConfigureInjectExtensions();

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                      Path.Combine(Directory.GetCurrentDirectory(), "Documents")),
    RequestPath = "/Documents"
});
app.UseAuthorization();

app.MapControllers();

app.Run();

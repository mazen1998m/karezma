using App.Dashboard.Services.InjectionService;
using App.Data.EFCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.AddAutoScoped();
builder.Services.AutoInjectedServices();
builder.Services.ConfigureValidator();

builder.Services.AddEfDbContext<EfDbContext>(builder);
builder.Services.ConfigureInjectExtensions();
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.f
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseMiddleware<JwtSessionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",

pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();

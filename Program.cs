var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:44457").WithHeaders("Authorization").WithMethods("GET","POST","DELETE") ;
    });
    option.AddPolicy("SameOriginspecific",builder =>
    {
        builder.WithOrigins("https://localhost:44457").WithHeaders("Authorization");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();

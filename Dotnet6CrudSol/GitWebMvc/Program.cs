var builder = WebApplication.CreateBuilder(args);

#region CONFIGURE DEPENDENCY INJECTION
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
#endregion


#region CONFIGURE REQUEST PIPELINE
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


//START : MIDDLEWARE
app.UseRouting();
app.UseAuthorization();
//END : MIDDLEWARE


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#endregion
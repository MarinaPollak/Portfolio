namespace SearchingMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
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

            // Update the default route to point to SearchController
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Search}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
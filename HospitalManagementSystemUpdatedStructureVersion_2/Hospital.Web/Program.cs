using Hospital.Web.Services;

namespace Hospital.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient<DoctorApiService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5071/api/");
            });

            builder.Services.AddHttpClient<PatientApiService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5071/api/");
            });

            builder.Services.AddHttpClient<AppointmentApiService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5071/api/");
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}

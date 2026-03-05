using Hospital.Application.Services;
using Hospital.Domain.Interfaces;
using Hospital.Infrastructure.Data;
using Hospital.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hospital.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DATABASE
            builder.Services.AddDbContext<HospitalDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("appdb")));

            // REPOSITORIES
            builder.Services.AddScoped<IDoctorRepository, DoctorRepositoryEF>();

            builder.Services.AddScoped<IPatientRepository>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("appdb") ?? "";

                return new PatientRepositoryADO(connectionString);
            });

            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepositoryEF>();

            // SERVICES
            builder.Services.AddScoped<DoctorService>();
            builder.Services.AddScoped<PatientService>();
            builder.Services.AddScoped<AppointmentService>();

            // CONTROLLERS
            builder.Services.AddControllers();

            // SWAGGER
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
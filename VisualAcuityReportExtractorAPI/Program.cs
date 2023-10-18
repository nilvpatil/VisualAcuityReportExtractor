using Microsoft.EntityFrameworkCore;
using VisualAcuityReportExtractorAPI.Data;
using VisualAcuityReportExtractorAPI.Helpers;
using VisualAcuityReportExtractorAPI.Repositories;
using VisualAcuityReportExtractorAPI.Repositories.Interfaces;

namespace VisualAcuityReportExtractorAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<VisualAcuityDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddScoped<IVisualTestResultRepository, VisualTestResultRepository>();

            var app = builder.Build();

            AppSettingsHelper.AppSettingConfigure(app.Services.GetRequiredService<IConfiguration>());

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
    }
}
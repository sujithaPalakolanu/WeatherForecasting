using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecasting.Areas.Identity.Data;
using WeatherForecasting.Data;

[assembly: HostingStartup(typeof(WeatherForecasting.Areas.Identity.IdentityHostingStartup))]
namespace WeatherForecasting.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WeatherForecastingContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WeatherForecastingContextConnection")));

                services.AddDefaultIdentity<WeatherForecastingUser>(
                    options =>
                    {
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.SignIn.RequireConfirmedAccount = false;
                    })
                    .AddEntityFrameworkStores<WeatherForecastingContext>();
            });
        }
    }
}
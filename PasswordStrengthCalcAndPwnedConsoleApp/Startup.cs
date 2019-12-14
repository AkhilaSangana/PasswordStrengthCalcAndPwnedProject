using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PasswordStrengthCalcAndPwnedProject;
using System;
using System.Collections.Generic;
using System.Text;


namespace PasswordStrengthCalcAndPwnedConsoleApp
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddSingleton<IPasswordStrengthService, PasswordStrengthService>();
            services.AddSingleton<IPwnedPasswordService, PwnedPasswordService>();
            services.AddPwnedPassword();
        }
    }
}

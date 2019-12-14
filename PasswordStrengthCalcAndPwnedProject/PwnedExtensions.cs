using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PasswordStrengthCalcAndPwnedProject
{
    public static class PwnedExtensions
    {
        public const string Pwned = nameof(Pwned);

        public const string DefaultPasswordName = nameof(PwnedPasswordService);

        public static IServiceCollection AddPwnedPassword(this IServiceCollection services)
        {
            return services.AddPwnedPassword(_ => new PwnedOptions());
        }

        public static IServiceCollection AddPwnedPassword(
            this IServiceCollection services,
            Action<PwnedOptions> options)
        {
            services.Configure(options);

            // The pwnedpassword API achieves 99% percentile of <1s, so this should be sufficient
            services.AddHttpClient(DefaultPasswordName)
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(2)))
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddTypedClient<IPwnedPasswordService, PwnedPasswordService>();
            return services;
        }
    }
}

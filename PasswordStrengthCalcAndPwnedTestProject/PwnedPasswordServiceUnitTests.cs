using Microsoft.Extensions.DependencyInjection;
using PasswordStrengthCalcAndPwnedProject;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordStrengthCalcAndPwnedTestProject
{
    public class PwnedPasswordServiceUnitTests
    {
        [Fact]
        public void SamplePasswordPwnedTestCase()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IPwnedPasswordService, PwnedPasswordService>();
            services.AddPwnedPassword();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var _pwnedPasswordService = serviceProvider.GetService<IPwnedPasswordService>();
            bool isPwnd = _pwnedPasswordService.IsPasswordPwnedAsync("password").Result.pwned;
            Assert.True(isPwnd);
        }

        [Fact]
        public void BlankPasswordPwnedTestCase()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IPwnedPasswordService, PwnedPasswordService>();
            services.AddPwnedPassword();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var _pwnedPasswordService = serviceProvider.GetService<IPwnedPasswordService>();
            bool isPwnd = _pwnedPasswordService.IsPasswordPwnedAsync("").Result.pwned;
            Assert.False(isPwnd);
        }

        [Fact]
        public void PwnedPasswordCountTestCase()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IPwnedPasswordService, PwnedPasswordService>();
            services.AddPwnedPassword();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var _pwnedPasswordService = serviceProvider.GetService<IPwnedPasswordService>();
            long count = _pwnedPasswordService.IsPasswordPwnedAsync("abcd").Result.count;
            Assert.True(count > 0, "The count should be greater than 0 ");
        }

        [Fact]
        public void PwnedPasswordCountZeroTestCase()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IPwnedPasswordService, PwnedPasswordService>();
            services.AddPwnedPassword();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var _pwnedPasswordService = serviceProvider.GetService<IPwnedPasswordService>();
            long count = _pwnedPasswordService.IsPasswordPwnedAsync("Ashok@4200").Result.count;
            Assert.True(count == 0, "The count should be 0 as the provided password is strong ");
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using PasswordStrengthCalcAndPwnedProject;
using System;

namespace PasswordStrengthCalcAndPwnedConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var _pwnedPasswordService = serviceProvider.GetService<IPwnedPasswordService>();
            var _passwordStrengthService = serviceProvider.GetService<IPasswordStrengthService>();

            Console.WriteLine("\nPassword should have minimum of 8 characters, atleast one uppercase letter and lowercase letter" +
                " and atleast one non-letter char (digit OR special char)");

            Console.WriteLine("\nPlease enter your password to know the strength and also number of times it appeared in data breach!");

            string password = Console.ReadLine();

            string passwordStrength = _passwordStrengthService.GetPasswordStrength(password);

            Console.WriteLine("\nYour password strength is " + passwordStrength);

            if (!"Blank".Equals(passwordStrength, StringComparison.OrdinalIgnoreCase))
            {
                string result = string.Empty;
                var pwnResult = _pwnedPasswordService.IsPasswordPwnedAsync(password).Result;

                if (pwnResult.pwned)
                {
                    result = string.Format("\nThe password you chose has appeared in a data breach {0} times. It is recommended that you chose different password.!!",
                                                 _pwnedPasswordService.IsPasswordPwnedAsync(password).Result.count);
                    Console.WriteLine(result);
                }
                else
                {
                    result = "\nYour chosen password not appeared in any data breach..!!";
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("\nThis is not a valid password");
            }
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}

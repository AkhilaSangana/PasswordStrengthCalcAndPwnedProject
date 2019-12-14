using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordStrengthCalcAndPwnedProject
{
    public class PasswordStrengthService : IPasswordStrengthService
    {
        public string GetPasswordStrength(string password)
        {
            int strengthScore = 0;
            if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(password.Trim()))
            {
                return PasswordStrength.Blank.ToString();
            }
            if (!UtilityManager.HasMinimumLength(password, 8))
            {
                return PasswordStrength.VeryWeak.ToString();
            }

            if (UtilityManager.HasMinimumLength(password, 8)) strengthScore++;
            if (UtilityManager.HasUpperCaseLetter(password)) strengthScore++;
            if (UtilityManager.HasLowerCaseLetter(password)) strengthScore++;
            if (UtilityManager.HasDigit(password)) strengthScore++;
            if (UtilityManager.HasSpecialChar(password)) strengthScore++;
            return ((PasswordStrength)strengthScore).ToString();

        }
        public static bool IsValidPassword(string password, Microsoft.AspNetCore.Identity.PasswordOptions options)
        {
            return UtilityManager.IsValidPassword(
                password,
                options.RequiredLength,
                options.RequiredUniqueChars,
                options.RequireNonAlphanumeric,
                options.RequireLowercase,
                options.RequireUppercase,
                options.RequireDigit);
        }

        public enum PasswordStrength
        {
            /// <summary>
            /// Blank Password (empty and/or space chars only)
            /// </summary>
            Blank = 0,
            /// <summary>
            /// Either too short (less than 5 chars), one-case letters only or digits only
            /// </summary>
            VeryWeak = 1,
            /// <summary>
            /// At least 5 characters, one strong condition met (>= 8 chars with 1 or more UC letters, LC letters, digits & special chars)
            /// </summary>
            Weak = 2,
            /// <summary>
            /// At least 5 characters, two strong conditions met (>= 8 chars with 1 or more UC letters, LC letters, digits & special chars)
            /// </summary>
            Medium = 3,
            /// <summary>
            /// At least 8 characters, three strong conditions met (>= 8 chars with 1 or more UC letters, LC letters, digits & special chars)
            /// </summary>
            Strong = 4,
            /// <summary>
            /// At least 8 characters, all strong conditions met (>= 8 chars with 1 or more UC letters, LC letters, digits & special chars)
            /// </summary>
            VeryStrong = 5
        }

    }
}

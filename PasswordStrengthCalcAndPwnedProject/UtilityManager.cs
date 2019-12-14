using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordStrengthCalcAndPwnedProject
{
    public class UtilityManager
    {
        //This class will have methods that can be utilised by any other modules in a solution if required.
        #region Helper Methods

        public static bool HasMinimumLength(string password, int minLength)
        {
            return password.Length >= minLength;
        }

        public static bool HasMinimumUniqueChars(string password, int minUniqueChars)
        {
            return password.Distinct().Count() >= minUniqueChars;
        }

        /// <summary>
        /// Returns TRUE if the password has at least one digit
        /// </summary>
        public static bool HasDigit(string password)
        {
            return password.Any(c => char.IsDigit(c));
        }

        /// <summary>
        /// Returns TRUE if the password has at least one special character
        /// </summary>
        public static bool HasSpecialChar(string password)
        {
            // return password.Any(c => char.IsPunctuation(c)) || password.Any(c => char.IsSeparator(c)) || password.Any(c => char.IsSymbol(c));
            return password.IndexOfAny("!@#$%^&*?_~-£().,".ToCharArray()) != -1;
        }

        /// <summary>
        /// Returns TRUE if the password has at least one uppercase letter
        /// </summary>
        public static bool HasUpperCaseLetter(string password)
        {
            return password.Any(c => char.IsUpper(c));
        }

        /// <summary>
        /// Returns TRUE if the password has at least one lowercase letter
        /// </summary>
        public static bool HasLowerCaseLetter(string password)
        {
            return password.Any(c => char.IsLower(c));
        }
        #endregion


        /// <summary>
        /// Sample password policy implementation following the Microsoft.AspNetCore.Identity.PasswordOptions standard.
        /// </summary>
        public static bool IsValidPassword(
            string password,
            int requiredLength,
            int requiredUniqueChars,
            bool requireNonAlphanumeric,
            bool requireLowercase,
            bool requireUppercase,
            bool requireDigit)
        {
            if (!UtilityManager.HasMinimumLength(password, requiredLength)) return false;
            if (!UtilityManager.HasMinimumUniqueChars(password, requiredUniqueChars)) return false;
            if (requireNonAlphanumeric && !UtilityManager.HasSpecialChar(password)) return false;
            if (requireLowercase && !UtilityManager.HasLowerCaseLetter(password)) return false;
            if (requireUppercase && !UtilityManager.HasUpperCaseLetter(password)) return false;
            if (requireDigit && !UtilityManager.HasDigit(password)) return false;
            return true;
        }


        /// <summary>
        /// Sample password policy implementation:
        /// - minimum 8 characters
        /// - at lease one UC letter
        /// - at least one LC letter
        /// - at least one non-letter char (digit OR special char)
        /// </summary>
        /// <returns></returns>
        public static bool IsStrongPassword(string password)
        {
            return UtilityManager.HasMinimumLength(password, 8)
                && UtilityManager.HasUpperCaseLetter(password)
                && UtilityManager.HasLowerCaseLetter(password)
                && (UtilityManager.HasDigit(password) || UtilityManager.HasSpecialChar(password));
        }
    }
}

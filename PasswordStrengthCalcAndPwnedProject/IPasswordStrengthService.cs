using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordStrengthCalcAndPwnedProject
{
    public interface IPasswordStrengthService
    {
        /// <summary>
        /// Returns password strength service that calculates and returns the password strength
        /// </summary>       
        /// <param name="password"></param>
        /// <returns>password strenth</returns>
        string GetPasswordStrength(string password);
    }
}

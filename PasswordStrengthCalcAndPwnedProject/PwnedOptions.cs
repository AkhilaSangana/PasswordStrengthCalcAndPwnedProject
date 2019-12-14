using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordStrengthCalcAndPwnedProject
{
    /// <example>
    ///"Pwned": {
    ///    "UserAgent": "",
    ///    "ServiceApiUrl": "https://haveibeenpwned.com/api/",
    ///    "ServiceApiVersion": "2",
    ///    "PasswordsApiUrl": "https://api.pwnedpasswords.com"
    ///   }
    /// </example>
    public class PwnedOptions
    {
        /// <summary>
        /// User Agent for the application.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// https://haveibeenpwned.com/api/v2/{service}/{parameter}
        /// </summary>
        public string ServiceApiUrl { get; set; } = @"https://haveibeenpwned.com/api/";

        /// <summary>
        /// Service Api Version.
        /// </summary>
        public string ServiceApiVersion { get; set; } = "2";

        /// <summary>
        /// https://haveibeenpwned.com/API/v2#PwnedPasswords
        /// </summary>
        public string PasswordsApiUrl { get; set; } = @"https://api.pwnedpasswords.com/";
    }
}

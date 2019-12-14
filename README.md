# PasswordStrengthCalcAndPwnedProject
This project solution has ConsoleApp, Service that is responsible for calculating the strength of a password and also Pwned information. Test project also been added for running test cases for the services.

# Get started working with this repo

This sample project can be cloned or downloaded to start with visual studio. The solution file can be opened from folder PasswordStrengthCalcAndPwnedProject which will load all 3 projects.

Three projects in this repository are 
1. Console App
2. Services (PasswordStrengthCalcAndPwnedProject)
3. Test project

Console app is responsible for displaying the result like the strength of the password, and also the number of times the password is compromised in data breach.

# What is HaveIBeenPwned

<a href="https://haveibeenpwned.com/">Haveibeenpwned.com</a> provides a means to check if user's private information has been leaked or compromised. Pwned.AspNetCore .NET Core implementation of the restful api allows integration of this service within Asp.Net Core application.

This library can be used to extend the Asp.Net Core Identity library to support with password and email check to see if users' private information has been compromised by recent known data breach.

Users can enter an email address, and see a list of all known data breaches with records tied to that email address. In addition custom details queries can be made to retrieve information of the each data breach, such as the backstory of the breach and what specific types of data were included in it.

Service URL: https://haveibeenpwned.com/api/ 

# Project Result

After running console app will gives result like below for a sample password entered that is abcd

````
Password should have minimum of 8 characters, atleast one uppercase letter and lowercase letter and atleast one non-letter char(digit or special character).

Please enter your password to know the strength and also the number of times it appeared in data breach!

abcd

Your password strenth is Veryweak
The password you chose has appeared in a data breach 66545 times. It is recommended that you chose different password.!!

````

# Additional Resources
<ul>
  <li><a href="https://haveibeenpwned.com/Passwords">Have I been pwned API</a></li>
  <li> <a href="https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity">Introduction to ASP.NET Core Identity</a>
  </li>
  <li><a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.1">HttpClient Factory in Ap.net      Core3.0</a></li>
</ul>

  

 

  

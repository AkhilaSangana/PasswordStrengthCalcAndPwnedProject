using PasswordStrengthCalcAndPwnedProject;
using System;
using Xunit;

namespace PasswordStrengthCalcAndPwnedTestProject
{
    public class PasswordStrengthServiceUnitTests
    {
        [Fact]
        public void BlankPasswordTestCase()
        {
            var test = new PasswordStrengthService();
            string actualValue = test.GetPasswordStrength("");
            Assert.Equal("Blank", actualValue);
        }

        [Fact]
        public void VeryWeakPasswordTestCase()
        {
            var test = new PasswordStrengthService();
            string actualValue = test.GetPasswordStrength("anbs");
            Assert.Equal("VeryWeak", actualValue);
        }

        [Fact]
        public void WeakPasswordTestCase()
        {
            var test = new PasswordStrengthService();
            string actualValue = test.GetPasswordStrength("abcdefga");
            Assert.Equal("Weak", actualValue);
        }

        [Fact]
        public void MediumPasswordTestCase()
        {
            var test = new PasswordStrengthService();
            string actualValue = test.GetPasswordStrength("AshokTest");
            Assert.Equal("Medium", actualValue);
        }

        [Fact]
        public void StrongPasswordTestCase()
        {
            var test = new PasswordStrengthService();
            string actualValue = test.GetPasswordStrength("Ashokte1");
            Assert.Equal("Strong", actualValue);
        }

        [Fact]
        public void VeryStrongPasswordTestCase()
        {
            var test = new PasswordStrengthService();
            string actualValue = test.GetPasswordStrength("AShok@410");
            Assert.Equal("VeryStrong", actualValue);
        }
    }
}

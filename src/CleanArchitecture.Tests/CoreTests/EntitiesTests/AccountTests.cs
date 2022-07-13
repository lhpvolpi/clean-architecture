using System;
using CleanArchitecture.Core.Entities;
using Xunit;

namespace CleanArchitecture.Tests.CoreTests.EntitiesTests
{
    public class AccountTests
    {
        public AccountTests() { }

        [Fact(DisplayName = "should create account")]
        public void Should_Create_Account()
        {
            // arrange
            var account = new Account("email@email.com", "admin", "admin@123");

            // act, assert
            Assert.NotNull(account);
        }

        [Fact(DisplayName = "should activate account")]
        public void Should_Activate_Account()
        {
            // arrange
            var account = new Account("email@email.com", "admin", "admin@123")
            {
                Active = false
            };

            // act
            account.Activate();

            // assert
            Assert.True(account.Active);
        }

        [Fact(DisplayName = "should inactivate account")]
        public void Should_Inactivate_Account()
        {
            // arrange
            var account = new Account("email@email.com", "admin", "admin@123");

            // act
            account.Inactivate();

            // assert
            Assert.False(account.Active);
        }

        [Fact(DisplayName = "should update account")]
        public void Should_Update_Account()
        {
            // arrange
            var account = new Account("email@email.com", "admin", "admin@123");

            // act
            account.Update("leovolpi");

            // assert
            Assert.NotNull(account);
        }

        [Fact(DisplayName = "should update account password")]
        public void Should_Update_Account_Password()
        {
            // arrange
            var account = new Account("email@email.com", "admin", "admin@123");

            // act
            account.UpdatePassword("Admin@123");

            // assert
            Assert.NotNull(account);
        }

        [Fact(DisplayName = "not should update account password when new password is null")]
        public void Not_Should_Update_Account_Password_When_New_Password_Is_Null()
        {
            // arrange
            var account = new Account("email@email.com", "admin", "admin@123");

            // act, assert
            Assert.ThrowsAny<ArgumentNullException>(() => account.UpdatePassword(string.Empty));
        }

        [Fact(DisplayName = "not should update the account password when the new password is the same as the old password")]
        public void Not_Should_Update_Account_Password_When_The_New_Password_Is_The_Same_As_The_Old_Password()
        {
            // arrange
            var account = new Account("email@email.com", "admin", "admin@123");

            // act, assert
            Assert.ThrowsAny<ArgumentException>(() => account.UpdatePassword("admin@123"));
        }
    }
}


using System;
using CleanArchitecture.Core.Entities;
using Xunit;

namespace CleanArchitecture.Tests.CoreTests.EntitiesTests
{
    public class UserTests
    {
        public UserTests() { }

        [Fact(DisplayName = "should create user")]
        public void Should_Create_User()
        {
            // arrange
            var user = new User("email@email.com", "admin", "admin@123");

            // act, assert
            Assert.NotNull(user);
        }

        [Fact(DisplayName = "should activate user")]
        public void Should_Activate_User()
        {
            // arrange
            var user = new User("email@email.com", "admin", "admin@123")
            {
                Active = false
            };

            // act
            user.Activate();

            // assert
            Assert.True(user.Active);
        }

        [Fact(DisplayName = "should inactivate user")]
        public void Should_Inactivate_User()
        {
            // arrange
            var user = new User("email@email.com", "admin", "admin@123");

            // act
            user.Inactivate();

            // assert
            Assert.False(user.Active);
        }

        [Fact(DisplayName = "should update user")]
        public void Should_Update_User()
        {
            // arrange
            var user = new User("email@email.com", "admin", "admin@123");

            // act
            user.Update("leo.volpi@email.com", "leo");

            // assert
            Assert.NotNull(user);
        }

        [Fact(DisplayName = "should change user password")]
        public void Should_Change_User_Password()
        {
            // arrange
            var user = new User("email@email.com", "admin", "admin@123");

            // act
            user.ChangePassword("Admin@123");

            // assert
            Assert.NotNull(user);
        }

        [Fact(DisplayName = "not should change user password when new password is null")]
        public void Not_Should_Change_User_Password_When_New_Password_Is_Null()
        {
            // arrange
            var user = new User("email@email.com", "admin", "admin@123");

            // act, assert
            Assert.ThrowsAny<ArgumentNullException>(() => user.ChangePassword(string.Empty));
        }

        [Fact(DisplayName = "not should change the user password when the new password is the same as the old password")]
        public void Not_Should_Change_User_Password_When_The_New_Password_Is_The_Same_As_The_Old_Password()
        {
            // arrange
            var user = new User("email@email.com", "admin", "admin@123");

            // act, assert
            Assert.ThrowsAny<ArgumentException>(() => user.ChangePassword("admin@123"));
        }
    }
}


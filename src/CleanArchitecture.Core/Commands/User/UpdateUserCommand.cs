using System;
using CleanArchitecture.Core.Interfaces.Commands;

namespace CleanArchitecture.Core.Commands.User
{
    public class UpdateUserCommand : ICommand
    {
        public UpdateUserCommand(Guid id, string email, string username)
        {
            this.Id = id;
            this.Email = email;
            this.Username = username;
        }

        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
    }
}


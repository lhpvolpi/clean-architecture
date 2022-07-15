using System;
using System.Threading.Tasks;
using CleanArchitecture.Core.Commands.Authenticate;
using CleanArchitecture.Core.Interfaces.CommandHandlers;
using CleanArchitecture.Core.Interfaces.Commands;

namespace CleanArchitecture.Core.Handlers
{
    public class AuthenticateCommandHandler : ICommandHandler<SignInCommand>
    {
        public AuthenticateCommandHandler() { }

        public Task<ICommandResult> Handle(SignInCommand command)
        {
            throw new NotImplementedException();
        }
    }
}


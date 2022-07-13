using System;
using System.Threading.Tasks;
using CleanArchitecture.Core.Commands.Account;
using CleanArchitecture.Core.Interfaces.CommandHandlers;
using CleanArchitecture.Core.Interfaces.Commands;

namespace CleanArchitecture.Core.Handlers
{
    public class AccountCommandHandler : ICommandHandler<CreateAccountCommand>
    {
        public AccountCommandHandler()
        {
        }

        public Task<ICommandResult> Handle(CreateAccountCommand command)
        {
            throw new NotImplementedException();
        }
    }
}


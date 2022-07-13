using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces.Commands;

namespace CleanArchitecture.Core.Interfaces.CommandHandlers
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}


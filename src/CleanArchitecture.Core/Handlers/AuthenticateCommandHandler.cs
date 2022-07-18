using System;
using System.Threading.Tasks;
using CleanArchitecture.Core.Commands.Authenticate;
using CleanArchitecture.Core.Common.Extensions;
using CleanArchitecture.Core.Interfaces.CommandHandlers;
using CleanArchitecture.Core.Interfaces.Commands;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Interfaces.Services;
using CleanArchitecture.Core.Validators.Authenticate;

namespace CleanArchitecture.Core.Handlers
{
    public class AuthenticateCommandHandler : ICommandHandler<SignInCommand>
    {
        private readonly IUserRepository _userRepository;

        private readonly IJwtService _jwtService;

        public AuthenticateCommandHandler(IUserRepository userRepository,
            IJwtService jwtService)
        {
            this._userRepository = userRepository;
            this._jwtService = jwtService;
        }

        public async Task<ICommandResult> Handle(SignInCommand command)
        {
            var validator = new SignInValidator();
            var validationResult = validator.Validate(command);

            if (!validationResult.IsValid)
                return CommandResultExtensions.CreateError422(command, validationResult);

            var user = await this._userRepository.GetByUsernameAsync(command.Username);

            if (user is null)
                return CommandResultExtensions.CreateError404(command, nameof(command.Username), "user not found");

            if (!user.Password.Equals(command.Password.ComputeSHA256Hash()))
                return CommandResultExtensions.CreateError406(command, nameof(command.Password), "worng password");

            var tokenVO = this._jwtService.GenerateToken(user);

            user.RefreshToken = tokenVO.RefreshToken;
            user.UpdatedAt = DateTime.UtcNow;

            await this._userRepository.UpdateAsync(user);

            return CommandResultExtensions.CreateSuccess200(tokenVO, "login successfully");
        }
    }
}


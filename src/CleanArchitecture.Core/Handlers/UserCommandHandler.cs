using System.Threading.Tasks;
using CleanArchitecture.Core.Commands.User;
using CleanArchitecture.Core.Common.Commands;
using CleanArchitecture.Core.Common.Extensions;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.CommandHandlers;
using CleanArchitecture.Core.Interfaces.Commands;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Interfaces.Services;
using CleanArchitecture.Core.Validators.User;

namespace CleanArchitecture.Core.Handlers
{
    public class UserCommandHandler : ICommandHandler<CreateUserCommand>,
        ICommandHandler<UpdateUserCommand>,
        ICommandHandler<ActivateUserCommand>,
        ICommandHandler<InactivateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        private readonly ICacheService _cacheService;

        private readonly ISmtpService _smtpService;

        public UserCommandHandler(IUserRepository userRepository,
            ICacheService cacheService,
            ISmtpService smtpService) => (this._userRepository, this._cacheService, this._smtpService) = (userRepository, cacheService, smtpService);

        public async Task<ICommandResult> Handle(CreateUserCommand command)
        {
            var validator = new CreateUserValidator();
            var validationResult = validator.Validate(command);

            if (!validationResult.IsValid)
                return CommandResultExtensions.CreateError422(command, validationResult);

            var usernameExists = await this._userRepository.GetByUsernameAsync(command.Username);

            if (usernameExists != null)
                return CommandResultExtensions.CreateError422(command, nameof(command.Username), "username exists");

            var emailExists = await this._userRepository.GetByUsernameAsync(command.Email);

            if (emailExists != null)
                return CommandResultExtensions.CreateError422(command, nameof(command.Email), "e-mail exists");

            var user = new User(command.Email, command.Username, command.Password);

            await this._userRepository.CreateAsync(user);
            await this._cacheService.SetAsync(user.Username, user);

            await this.SendConfirmationCode(user.Email, user.Code);

            return CommandResultExtensions.CreateSuccess200(user, EMetadataType.Object, "user created successfully");
        }

        public async Task<ICommandResult> Handle(UpdateUserCommand command)
        {
            var validator = new UpdateUserValidator();
            var validationResult = validator.Validate(command);

            if (!validationResult.IsValid)
                return CommandResultExtensions.CreateError422(command, validationResult);

            var user = await this._userRepository.GetByIdAsync(command.Id);

            if (user is null)
                return CommandResultExtensions.CreateError404(command, nameof(user.Email), "user not found");

            await this._cacheService.DeleteAsync(user.Email);

            user.Update(command.Email, command.Username);

            await this._userRepository.UpdateAsync(user);
            await this._cacheService.SetAsync(user.Email, user);

            return CommandResultExtensions.CreateSuccess200(user, EMetadataType.Object, "user updated successfully");
        }

        public async Task<ICommandResult> Handle(ActivateUserCommand command)
        {
            var validator = new ActivateUserValidator();
            var validationResult = validator.Validate(command);

            if (!validationResult.IsValid)
                return CommandResultExtensions.CreateError422(command, validationResult);

            var user = await this._userRepository.GetByUsernameAsync(command.Email);

            if (user is null)
                return CommandResultExtensions.CreateError404(command, nameof(user.Email), "user not found");

            user.Activate();

            await this._userRepository.UpdateAsync(user);
            await this._cacheService.SetAsync(user.Email, user);

            return CommandResultExtensions.CreateSuccess200(user, EMetadataType.Object, "user activated successfully");
        }

        public async Task<ICommandResult> Handle(InactivateUserCommand command)
        {
            var validator = new InactivateUserValidator();
            var validationResult = validator.Validate(command);

            if (!validationResult.IsValid)
                return CommandResultExtensions.CreateError422(command, validationResult);

            var user = await this._userRepository.GetByUsernameAsync(command.Email);

            if (user is null)
                return CommandResultExtensions.CreateError404(command, nameof(user.Email), "user not found");

            await this._cacheService.DeleteAsync(user.Email);

            user.Inactivate();

            await this._userRepository.UpdateAsync(user);

            return CommandResultExtensions.CreateSuccess200(user, EMetadataType.Object, "user inactivated successfully");
        }

        // privates
        private async Task SendConfirmationCode(string email, string code)
        {
            var mail = new Mail(email, "Welcome to Clean Architecture App", $"Confirm your code({code})");

            await this._smtpService.SendAsync(mail);
        }
    }
}


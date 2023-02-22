
using FinanceApp.Core.Commands;
using Microsoft.AspNetCore.Identity;

namespace FinanceApp.Identity.API.Application.Commands
{
    public interface IUserCommandHandler : ICommandHandler<UserCommand>
    {
        Task<IdentityResult> CreateUserHandle( UserCommand command );
        Task<bool> VerifyUserHandle(UserCommand command );
    }

    public class UserCommandHandler : IUserCommandHandler
    {
        public async Task<IdentityResult> CreateUserHandle( UserCommand command )
        {

            return await command.CreateUser();
        }

        public async Task<bool> VerifyUserHandle( UserCommand command )
        {
            var userExists = await command.VerifyUser();

            if (userExists != null)
                return true;

            return false;
        }
    }
}

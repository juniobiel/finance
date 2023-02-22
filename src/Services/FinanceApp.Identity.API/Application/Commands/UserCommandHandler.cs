
using FinanceApp.Core.Commands;
using FinanceApp.Identity.API.Models;
using Microsoft.AspNetCore.Identity;

namespace FinanceApp.Identity.API.Application.Commands
{
    public interface IUserCommandHandler : ICommandHandler<UserCommand>
    {
        Task<IdentityResult> CreateUserHandle( UsuarioRegistro usuarioRegistro );
        Task<bool> VerifyUserHandle( UsuarioRegistro usuarioRegistro );
        Task<SignInResult> LoginUserHandle( UsuarioLogin usuarioLogin );

        Task LogoutUserHandle();

    }

    public class UserCommandHandler : IUserCommandHandler
    {
        private readonly IUserCommand _userCommand;

        public UserCommandHandler( IUserCommand userCommand )
        {
            _userCommand = userCommand;
        }

        public async Task<IdentityResult> CreateUserHandle( UsuarioRegistro usuarioRegistro )
        {

            return await _userCommand.CreateUser(usuarioRegistro);
        }

        public async Task<SignInResult> LoginUserHandle( UsuarioLogin usuarioLogin )
        {
            return await _userCommand.LoginUser(usuarioLogin);
        }

        public async Task LogoutUserHandle()
        {
            await _userCommand.LogoutUser();
        }

        public async Task<bool> VerifyUserHandle( UsuarioRegistro usuarioRegistro )
        {
            var userExists = await _userCommand.VerifyUser(usuarioRegistro);

            if (userExists != null)
                return true;

            return false;
        }
    }
}

using FinanceApp.Core.Commands;
using FinanceApp.Identity.API.Models;
using Microsoft.AspNetCore.Identity;

namespace FinanceApp.Identity.API.Application.Commands
{
    public interface IUserCommands
    {
        Task<IdentityResult> CreateUser();
        Task<IdentityUser> VerifyUser();
    }

    public class UserCommand : Command, IUserCommands
    {
        private readonly UsuarioRegistro UsuarioRegistro;
        private readonly UserManager<IdentityUser> _userManager;

        public UserCommand( UsuarioRegistro usuarioRegistro, UserManager<IdentityUser> userManager )
        {
            UsuarioRegistro = usuarioRegistro;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUser()
        {
            var user = new IdentityUser
            {
                UserName = UsuarioRegistro.UserName,
                Email = UsuarioRegistro.Email,
                EmailConfirmed = true
            };

            return await _userManager.CreateAsync(user, UsuarioRegistro.Senha);
        }

        public async Task<IdentityUser> VerifyUser()
        {
            return await _userManager.FindByEmailAsync(UsuarioRegistro.Email);
        }
    }
}

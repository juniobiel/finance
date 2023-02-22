using FinanceApp.Core.Commands;
using FinanceApp.Identity.API.Models;
using Microsoft.AspNetCore.Identity;

namespace FinanceApp.Identity.API.Application.Commands
{
    public interface IUserCommand
    {
        Task<IdentityResult> CreateUser( UsuarioRegistro usuarioRegistro );
        Task<IdentityUser> VerifyUser( UsuarioRegistro usuarioRegistro );

        Task<SignInResult> LoginUser(UsuarioLogin usuarioLogin);
    }

    public class UserCommand : Command, IUserCommand
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserCommand( UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser( UsuarioRegistro usuarioRegistro )
        {
            var user = new IdentityUser
            {
                UserName = usuarioRegistro.UserName,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            return await _userManager.CreateAsync(user, usuarioRegistro.Senha);
        }

        public async Task<IdentityUser> VerifyUser( UsuarioRegistro usuarioRegistro )
        {
            return await _userManager.FindByEmailAsync(usuarioRegistro.Email);
        }

        public async Task<SignInResult> LoginUser(UsuarioLogin usuarioLogin)
        {
            return await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha,
                false, true);
        }
    }
}

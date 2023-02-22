using FinanceApp.Core.Commands;
using FinanceApp.Core.User;
using FinanceApp.Identity.API.Models;
using Microsoft.AspNetCore.Identity;

namespace FinanceApp.Identity.API.Application.Commands
{
    public interface IUserCommand
    {
        Task<IdentityResult> CreateUser( UsuarioRegistro usuarioRegistro );
        Task<IdentityUser> VerifyUser( UsuarioRegistro usuarioRegistro );

        Task<SignInResult> LoginUser(UsuarioLogin usuarioLogin);
        Task LogoutUser();
    }

    public class UserCommand : Command, IUserCommand
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAspNetUser _user;

        public UserCommand( UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            IAspNetUser user )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _user = user;
        }

        public async Task<IdentityResult> CreateUser( UsuarioRegistro usuarioRegistro )
        {
            var user = new IdentityUser
            {
                UserName = usuarioRegistro.Email,
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

        public async Task LogoutUser()
        {
            if (_user.EstaAutenticado())
                await _signInManager.SignOutAsync();
        }
    }
}

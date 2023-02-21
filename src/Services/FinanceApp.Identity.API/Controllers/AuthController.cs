using FinanceApp.Identity.API.Models;
using FinanceApp.Services.Core.Controllers;
using FinanceApp.Services.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FinanceApp.Identity.API.Controllers
{
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AuthController( SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<AppSettings> appSettings )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("create-account")]
        public async Task<ActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var existsUser = await _userManager.FindByEmailAsync(usuarioRegistro.Email);
            
            if(existsUser != null)
            {
                AdicionarErroProcessamento("Usuário já existente!");
            }

            var user = new IdentityUser
            {
                UserName = usuarioRegistro.Nome,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

            foreach (var error in result.Errors)
            {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse("Usuário registrado com sucesso");
        }
    }
}

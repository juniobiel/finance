using FinanceApp.Identity.API.Application.Commands;
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
        private readonly IUserCommandHandler _userCommandsHandler;

        public AuthController( SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<AppSettings> appSettings,
            IUserCommandHandler userCommandsHandler )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _userCommandsHandler = userCommandsHandler;
        }

        [HttpPost("create-account")]
        public async Task<ActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var userCommand = new UserCommand(usuarioRegistro, _userManager);

            var existsUser = await _userCommandsHandler.VerifyUserHandle(userCommand);
            
            if(existsUser)
            {
                AdicionarErroProcessamento("Usuário já existente!");
            }

            var result = await _userCommandsHandler.CreateUserHandle(userCommand);

            foreach (var error in result.Errors)
            {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse("Usuário registrado com sucesso");
        }
    }
}

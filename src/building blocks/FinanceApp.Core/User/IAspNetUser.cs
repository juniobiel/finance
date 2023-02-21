﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinanceApp.Core.User
{
    public interface IAspNetUser
    {
        string Name { get; }
        Guid ObterUserId();
        string ObterUserEmail();
        string ObterUserToken();
        bool EstaAutenticado();
        bool PossuiRole( string role );
        IEnumerable<Claim> ObterClaims();
        HttpContext ObterHttpContext();
    }
}

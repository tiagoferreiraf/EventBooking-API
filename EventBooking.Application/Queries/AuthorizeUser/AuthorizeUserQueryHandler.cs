using EventBooking.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Queries.AuthorizeUser
{
    public class AuthorizeUserQueryHandler : IRequestHandler<AuthorizeUserQuery, string>
    {
        private readonly IAuthenticate _authService;

        public AuthorizeUserQueryHandler(IAuthenticate authService, IUserService userService)
        {
            _authService = authService;
        }

        public Task<string> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var exists = _authService.UserExists(request.Email).Result;
            if (!exists) throw new Exception("Usuário não existe.");

            var result = _authService.AuthenticateAsync(request.Email, request.Password).Result;
            if (!result) throw new Exception("Usuário ou senha inválidos.");

            var usuario = _authService.GetUserByEmail(request.Email);

            var token = _authService.GenerateToken(usuario.Result.Id, usuario.Result.Email);

            return Task.FromResult(token);

        }
    }
}

using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using EventBooking.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, string>
    {
        private readonly IAuthenticate _authService;
        private readonly IUserService _userService;

        public AddUserCommandHandler(IAuthenticate authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public Task<string> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new Exception("Dados inválidos");

            var emailExists = _authService.UserExists(request.Email).Result;

            if (emailExists == true) throw new Exception("Já existe conta cadastrada com o e-mail");

            UserModel userModel = new UserModel{
                Name = request.Name, 
                Email = request.Email, 
                Password = request.Password
            };
            var lUser = _userService.Add(userModel);

            if (lUser == null) throw new Exception("Dados inválidos");

            var token = _authService.GenerateToken(lUser.Id, request.Email);

            return Task.FromResult(token);
        }
    }
}

using CreditApplicationSystem.ApplicationServices.API.Domain;
using CreditApplicationSystem.ApplicationServices.API.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.API.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AuthenticationSettings _authenticationSettings;


        public LoginUserHandler(SignInManager<IdentityUser> signInManager, AuthenticationSettings authenticationSettings)
        {
            _signInManager = signInManager;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _signInManager.UserManager.Users.FirstOrDefaultAsync(u => u.UserName == request.Username, cancellationToken: cancellationToken);
            
            var response = new LoginUserResponse();
            
            if (user is null)
            {
                response.Error = new ErrorModel("Invalid username or password");
            }

            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            
            if (result.Succeeded)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    //new Claim(ClaimTypes.Role, $"{user.Role.Name}")
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var expires = DateTime.UtcNow.AddDays(_authenticationSettings.JwtExpireDays);

                var token = new JwtSecurityToken(
                    _authenticationSettings.JwtIssuer, 
                    _authenticationSettings.JwtIssuer,
                    claims, 
                    expires: expires, 
                    signingCredentials: credentials);

                var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
                response.Data = tokenHandler;
            }
            else
            {
                response.Error = new ErrorModel("Invalid username or password");
            }

            return response;
        }
    }
}
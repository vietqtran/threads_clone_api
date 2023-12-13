using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.Contracts.Identity;
using Threads.Application.Exceptions;
using Threads.Application.Models.Identity;
using Threads.Identity.Models;

namespace Threads.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AuthenticationUser> _userManager;
        private readonly SignInManager<AuthenticationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService (UserManager<AuthenticationUser> userManager, IOptions<JwtSettings> jwtSettings, SignInManager<AuthenticationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResponse> Login (AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new EmailNotFoundException(request.Email);
            }

            var loginResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!loginResult.Succeeded)
            {
                throw new InvalidPasswordException(request.Password);
            }

            var token = await GenerateToken(user);

            return new AuthenticationResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserId = user.Id,
                UserName = user.UserName
            };
        }

        public async Task<RegistrationResponse> Register (RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);
            if (existingUser != null)
            {
                throw new SomethingWentWrongException();
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                throw new EmailAlreadyExistsException(request.Email);
            }
            else
            {
                var createdUser = new AuthenticationUser
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Name = request.Name
                };

                var result = await _userManager.CreateAsync(createdUser, request.Password);
                if (!result.Succeeded)
                {
                    throw new SomethingWentWrongException();
                }

                return new RegistrationResponse
                {
                    UserId = createdUser.Id.ToString(),
                    UserName = createdUser.UserName,
                    Email = createdUser.Email,
                    Name = createdUser.Name,
                };
            }
        }

        public async Task RevokeIdentityUser (Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }

        private async Task<JwtSecurityToken> GenerateToken (AuthenticationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new Claim("Id", user.Id.ToString())
            };

            claims.AddRange(userClaims);
            claims.AddRange(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}

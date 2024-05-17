using HepsiApi.Application.Bases;
using HepsiApi.Application.Features.Auth.Rules;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.Tokens;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly AuthRules authRules;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly UserManager<User> userManager;

        public LoginCommandHandler(AuthRules authRules,IConfiguration configuration,ITokenService tokenService,UserManager<User> userManager,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.userManager = userManager;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {

            User user= await userManager.FindByEmailAsync(request.Email);

            bool checkPassword= await userManager.CheckPasswordAsync(user,request.Password);

            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

            IList<string> roles= await userManager.GetRolesAsync(user); //bir kullanıcının birden fazla rolü olabilir

            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            string refreshToken = tokenService.GenerateRefreshToken();

            _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);   // app.settings.Development daki JWt içindeki değeri adlık burda

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpireTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string _token= new JwtSecurityTokenHandler().WriteToken(token);

            await userManager.SetAuthenticationTokenAsync(user, "Default" ,"AccessToken" , _token);

            return new()
            {
                Token= _token,
                RefreshToken = refreshToken,
                Expiration= token.ValidTo
            };
        
        
        
        
        
        
        }
    }
}

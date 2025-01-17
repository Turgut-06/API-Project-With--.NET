﻿using HepsiApi.Application.Bases;
using HepsiApi.Application.Features.Auth.Rules;
using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Application.Interfaces.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit> //dönüş tipi unit
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager; //kullanıcı register olurken ona rol de atamamız lazım

        //base olan BaseHandler constructorına verileri yolluyoruz
        public RegisterCommandHandler(AuthRules authRules ,UserManager<User> userManager,RoleManager<Role> roleManager,IMapper mapper,IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor) : base(mapper,unitOfWork,httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {

            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            User user = mapper.Map< User, RegisterCommandRequest> (request);

            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString(); // bir nesne aynı anda 2 kişi tarafından güncelleniyorsa ilk tuşa basan hangisi onu saptamak için 
        
            IdentityResult result = await userManager.CreateAsync(user,request.Password);

            if(result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("user"))   //user rolü sistemde yoksa oluşturup register olan kullanıcıya atacağız
                    await roleManager.CreateAsync( new Role
                    {
                        Id= Guid.NewGuid(),
                        Name="user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString()

                    });

                await userManager.AddToRoleAsync(user, "user");
                        
            }

            return Unit.Value;

        }
    }
}

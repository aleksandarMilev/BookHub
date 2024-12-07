﻿namespace BookHub.Server.Features.Identity.Web
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Models;
    using Service;

    using static Common.Constants;
    using static ErrorMessage;

    public class IdentityController(
        IIdentityService service,
        UserManager<User> userManager,
        IOptions<AppSettings> appSettings) : ApiController
    {
        private readonly IIdentityService service = service;
        private readonly UserManager<User> userManager = userManager;
        private readonly AppSettings appSettings = appSettings.Value;

        [HttpPost(ApiRoutes.Register)]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = new User()
            {
                Email = model.Email,
                UserName = model.Username
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var token = this.service.GenerateJwtToken(
                    this.appSettings.Secret,
                    user.Id,
                    user.UserName,
                    user.Email);

                return this.Ok(new LoginResponseModel(token));
            }

            var errorMessage = result
                .Errors
                .Select(e => e.Description)
                .ToList();

            return this.Unauthorized(new { errorMessage });
        }

        [HttpPost(ApiRoutes.Login)]
        public async Task<ActionResult> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Credentials);

            if (user is null)
            {
                user = await this.userManager.FindByEmailAsync(model.Credentials);

                if (user is null)
                {
                    return this.Unauthorized(new { errorMessage = InvalidLoginAttempt });
                }
            }

            if (await this.userManager.IsLockedOutAsync(user))
            {
                return this.Unauthorized(new { errorMessage = AccountIsLocked });
            }

            var passwordIsValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (passwordIsValid)
            {
                await this.userManager.ResetAccessFailedCountAsync(user);

                var isAdmin = await this.userManager.IsInRoleAsync(user, AdminRoleName);

                var token = this.service.GenerateJwtToken(
                    this.appSettings.Secret,
                    user.Id,
                    user.UserName!,
                    user.Email!,
                    model.RememberMe,
                    isAdmin);

                return this.Ok(new LoginResponseModel(token));
            }

            await this.userManager.AccessFailedAsync(user);

            if (await this.userManager.IsLockedOutAsync(user))
            {
                return this.Unauthorized(new { errorMessage = AccountWasLocked });
            }

            return this.Unauthorized(new { errorMessage = InvalidLoginAttempt });
        }
    }
}

﻿namespace BookHub.Server.Areas.Admin.Service
{
    using BookHub.Server.Features.Identity.Data.Models;
    using Data.Models;
    using Microsoft.AspNetCore.Identity;

    using static BookHub.Server.Common.Constants;

    public class AdminService(UserManager<User> userManager) : IAdminService
    {
        private readonly UserManager<User> userManager = userManager;

        public async Task<string> GetIdAsync()
        {
            var admin = await userManager.FindByEmailAsync(AdminEmail);

            if (admin != null)
            {
                return admin.Id;
            }

            throw new InvalidOperationException("Admin not found!");
        }
    }
}

﻿namespace BookHub.Server.Features.UserProfile.Service
{
    using Infrastructure.Services;
    using Infrastructure.Services.ServiceLifetimes;
    using Models;

    public interface IProfileService : ITransientService
    {
        Task<ProfileServiceModel?> MineAsync();

        Task<IEnumerable<ProfileServiceModel>> TopThreeAsync();

        Task<IProfileServiceModel?> OtherUserAsync(string id);

        Task<string> CreateAsync(CreateProfileServiceModel model);

        Task<Result> EditAsync(CreateProfileServiceModel model);

        Task<Result> DeleteAsync();

        Task UpdateCountAsync(
            string userId,
            string propName,
            Func<int, int> updateFunc);

        Task<bool> MoreThanFiveCurrentlyReadingAsync(string userId);
    }
}

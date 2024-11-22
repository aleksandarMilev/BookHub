﻿namespace BookHub.Server.Features.Authors.Service
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class NationalityService(BookHubDbContext data) : INationalityService
    {
        private readonly BookHubDbContext data = data;

        public async Task<IEnumerable<NationalityServiceModel>> NamesAsync()
           => await data
                .Nationalities
                .Select(n => new NationalityServiceModel()
                {
                    Id = n.Id,
                    Name = n.Name
                })
                .ToListAsync();
    }
}
﻿namespace BookHub.Server.Features.UserProfile.Web.User
{
    using AutoMapper;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Service;
    using Service.Models;

    using static Server.Common.ApiRoutes;

    [Authorize]
    public class ProfileController(
        IProfileService service,
        IMapper mapper) : ApiController
    {
        private readonly IProfileService service = service;
        private readonly IMapper mapper = mapper;

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Top)]
        public async Task<ActionResult<IEnumerable<ProfileServiceModel>>> TopThree()
            => this.Ok(await this.service.TopThreeAsync());

        [HttpGet(ApiRoutes.Exists)]
        public async Task<ActionResult<bool>> Exists()
            => this.Ok(await this.service.HasProfileAsync());

        [HttpGet(ApiRoutes.Mine)]
        public async Task<ActionResult<ProfileServiceModel>> Mine()
            => this.Ok(await this.service.MineAsync());

        [HttpGet(Id)]
        public async Task<ActionResult<IProfileServiceModel>> OtherUser(string id)
            => this.Ok(await this.service.OtherUserAsync(id));

        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateProfileWebModel webModel)
        {
            var serviceModel = this.mapper.Map<CreateProfileServiceModel>(webModel);
            var id = await this.service.CreateAsync(serviceModel);

            return this.Created(nameof(this.Create), id);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(CreateProfileWebModel webModel)
        {
            var serviceModel = this.mapper.Map<CreateProfileServiceModel>(webModel);
            var result = await this.service.EditAsync(serviceModel);

            return this.NoContentOrBadRequest(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            var result = await this.service.DeleteAsync();

            return this.NoContentOrBadRequest(result);
        }
    }
}

﻿#pragma warning disable ASP0023 
namespace BookHub.Server.Features.Authors.Web.User
{
    using AutoMapper;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Service;
    using Service.Models;

    [Authorize]
    public class AuthorController(
        IAuthorService service,
        IMapper mapper) : ApiController
    {
        private readonly IAuthorService service = service;
        private readonly IMapper mapper = mapper;

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<AuthorServiceModel>>> TopThree()
           => Ok(await service.TopThreeAsync());

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<AuthorNamesServiceModel>>> Names()
            => Ok(await service.NamesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDetailsServiceModel>> Details(int id)
            => Ok(await service.DetailsAsync(id));

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateAuthorWebModel webModel)
        {
            var serviceModel = mapper.Map<CreateAuthorServiceModel>(webModel);
            var authorId = await service.CreateAsync(serviceModel);

            return Created(nameof(this.Create), authorId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, CreateAuthorWebModel webModel)
        {
            var serviceModel = mapper.Map<CreateAuthorServiceModel>(webModel);
            var result = await service.EditAsync(id, serviceModel);

            return this.NoContentOrBadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await service.DeleteAsync(id);

            return this.NoContentOrBadRequest(result);
        }
    }
}
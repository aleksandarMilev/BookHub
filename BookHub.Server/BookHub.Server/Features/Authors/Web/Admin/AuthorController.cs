﻿namespace BookHub.Server.Features.Authors.Web.Admin
{
    using Areas.Admin.Web;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Service;
    using Service.Models;

    using static ApiRoutes;
    using static Common.Constants.ApiRoutes.CommonRoutes;

    [Authorize]
    public class AuthorController(IAuthorService service) : AdminApiController
    {
        private readonly IAuthorService service = service;

        [HttpGet(Id)]
        public async Task<ActionResult<AuthorDetailsServiceModel>> Details(int id)
          => this.Ok(await this.service.AdminDetailsAsync(id));

        [HttpPatch(Id + Author.Approve)]
        public async Task<ActionResult> Approve(int id)
        {
            var result = await this.service.ApproveAsync(id);

            return this.NoContentOrBadRequest(result);
        }

        [HttpPatch((Id + Author.Reject))]
        public async Task<ActionResult> Reject(int id)
        {
            var result = await this.service.RejectAsync(id);

            return this.NoContentOrBadRequest(result);
        }
    }
}

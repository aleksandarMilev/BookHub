﻿namespace BookHub.Server.Areas.Admin.Web
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static BookHub.Server.Common.Constants;

    [ApiController]
    [Area(AdminRoleName)]
    [Route("[area]/[controller]")]
    [Authorize(Roles = AdminRoleName)]
    public abstract class AdminApiController : ControllerBase
    {
    }
}

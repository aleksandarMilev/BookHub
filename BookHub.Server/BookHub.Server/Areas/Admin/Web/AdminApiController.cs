﻿namespace BookHub.Server.Areas.Admin.Web
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.Constants.Constants;

    [ApiController]
    [Area(AdminRoleName)]
    [Route("[area]/[controller]")]
    [Authorize(Roles = AdminRoleName)]
    public abstract class AdminApiController : ControllerBase
    {
    }
}

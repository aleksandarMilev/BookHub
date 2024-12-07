﻿namespace BookHub.Server.Features.Chat.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.Constants.Validation.Chat;

    public class AddUserToChatWebModel
    {
        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string ChatName { get; set; } = null!;
    }
}
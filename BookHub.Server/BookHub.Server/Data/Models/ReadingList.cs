﻿namespace BookHub.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Base;
    using Enums;
    using Microsoft.EntityFrameworkCore;

    [PrimaryKey(nameof(UserId), nameof(BookId), nameof(Status))]
    public class ReadingList : IEntity
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        public Book Book { get; set; } = null!;

        public ReadingListStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }
    }
}

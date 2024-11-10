﻿namespace BookHub.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BookHub.Server.Data.Models.Base;
    using BookHub.Server.Data.Models.Enums;

    using static BookHub.Server.Common.Constants.Validation.Author;

    public class Author : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; } = null!;

        [MaxLength(PenNameMaxLength)]
        public string? PenName { get; set; }

        public double Rating { get; set; }

        public Nationality Nationality { get; set; }

        public Gender Gender { get; set; }

        public DateTime? BornAt { get; set; }

        public DateTime? DiedAt { get; set; }

        public ICollection<Book> Books { get; } = new HashSet<Book>();
    }
}

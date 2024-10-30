﻿namespace BookHub.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using BookHub.Server.Data.Models.Base;

    using static BookHub.Server.Data.Common.Validation.Book;

    public class Book : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; } 

        public User? User { get; set; } 
    }
}

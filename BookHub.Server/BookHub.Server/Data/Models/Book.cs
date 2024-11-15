﻿namespace BookHub.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Base;

    using static Common.Constants.Validation.Book;

    public class Book : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ShortDescriptionMaxLength)]
        public string ShortDescription { get; set; } = null!;

        [Required]
        [MaxLength(LongDescriptionMaxLength)]
        public string LongDescription { get; set; } = null!;

        public double AverageRating { get; set; }

        public int RatingsCount { get; set; }

        public DateTime? PublishedDate { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [ForeignKey(nameof(Author))]
        public int? AuthorId { get; set; }

        public Author? Author { get; set; }

        [ForeignKey(nameof(User))]
        public string? CreatorId { get; set; }

        public User? Creator { get; set; }

        public ICollection<BookGenre> BooksGenres { get; } = new HashSet<BookGenre>();

        public ICollection<Review> Reviews { get; } = new HashSet<Review>();  
    }
}

﻿namespace BookHub.Server.Features.Books
{
    public class BookListResponseModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string Author { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
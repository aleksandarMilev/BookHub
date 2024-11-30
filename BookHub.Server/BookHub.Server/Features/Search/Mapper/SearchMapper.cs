﻿namespace BookHub.Server.Features.Search.Mapper
{
    using AutoMapper;
    using Book.Service.Models;
    using BookHub.Server.Features.Genre.Service.Models;
    using Data.Models;
    using Service.Models;

    public class SearchMapper : Profile
    {
        public SearchMapper()
        {
            this.CreateMap<Genre, GenreNameServiceModel>();

            this.CreateMap<Book, SearchBookServiceModel>()
                 .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.BooksGenres.Select(bg => bg.Genre)))
                 .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author == null ? null : src.Author.Name));

            this.CreateMap<Article, SearchArticleServiceModel>();
        }
    }
}

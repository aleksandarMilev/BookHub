﻿namespace BookHub.Server.Features.Search.Mapper
{
    using AutoMapper;
    using Data.Models;
    using Service.Models;

    public class SearchMapper : Profile
    {
        public SearchMapper()
        {
            this.CreateMap<Book, SearchBookServiceModel>()
             .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.BooksGenres.Select(bg => bg.Genre.Name).ToList()))
             .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author == null ? null : src.Author.Name));
        }
    }
}

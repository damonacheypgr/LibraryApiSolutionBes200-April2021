using AutoMapper;
using LibraryApi.Domain;
using LibraryApi.Models.Books;
using System;

namespace LibraryApi.AutomapperProfiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            // Book -> GetBookDetailsResponse
            CreateMap<Book, GetBookDetailsResponse>();
            // Book -> BookSummaryItem
            CreateMap<Book, BookSummaryItem>();

            CreateMap<PostBookRequest, Book>()
                .ForMember(dest => dest.AddedToInventory, cfg => cfg.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.IsAvailable, cfg => cfg.MapFrom(_ => true));
        }
    }
}

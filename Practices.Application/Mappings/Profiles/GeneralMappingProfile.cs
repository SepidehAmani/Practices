﻿using AutoMapper;
using Practices.Application.DTOs;
using Practices.Domain.Entities;

namespace Practices.Application.Mappings.Profiles;

public class GeneralMappingProfile : Profile
{
    public GeneralMappingProfile()
    {
        CreateMap<CreateAuthorDTO, Author>();
        CreateMap<CreateBookDTO, Book>();

        CreateMap<Author, AuthorWithBooksDTO>()
            .ForMember(des => des.Books , opt => opt.MapFrom(src=> src.Books));
        CreateMap<Book, BookDTO>()
            .ForMember(des => des.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(des => des.AuthorId, opt => opt.MapFrom(src => src.Author.Id));
    }
}
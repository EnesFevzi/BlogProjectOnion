﻿using AutoMapper;
using BlogProjectOnion.Application.DTOs.AuthorDTOs;
using BlogProjectOnion.Application.DTOs.CommentDTOs;
using BlogProjectOnion.Application.DTOs.GenreDTOs;
using BlogProjectOnion.Application.DTOs.LikeDTOs;
using BlogProjectOnion.Application.DTOs.PostDTOs;
using BlogProjectOnion.Domain.Entities;

namespace BlogProjectOnion.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<AuthorAddDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, AuthorDto>().ReverseMap();


            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<CommentAddDto, Comment>().ReverseMap();
            CreateMap<CommentUpdateDto, Comment>().ReverseMap();
            CreateMap<CommentUpdateDto, CommentDto>().ReverseMap();


            CreateMap<GenreDto, Genre>().ReverseMap();
            CreateMap<GenreAddDto, Genre>().ReverseMap();
            CreateMap<GenreUpdateDto, Genre>().ReverseMap();
            CreateMap<GenreUpdateDto, Genre>().ReverseMap();


            CreateMap<LikeDto, Like>().ReverseMap();
            CreateMap<LikeAddDto, Like>().ReverseMap();
            CreateMap<LikeUpdateDto, Like>().ReverseMap();
            CreateMap<LikeUpdateDto, LikeDto>().ReverseMap();



            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<PostAddDto, Post>().ReverseMap();
            CreateMap<PostUpdateDto, Post>().ReverseMap();
            CreateMap<PostUpdateDto, PostDto>().ReverseMap();

        }
    }
}

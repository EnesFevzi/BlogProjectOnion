using AutoMapper;
using BlogProjectOnion.Application.DTOs.PostDTOs;
using BlogProjectOnion.Application.Extensions;
using BlogProjectOnion.Application.Helpers.Abstract;
using BlogProjectOnion.Application.Services.Abstract;
using BlogProjectOnion.Domain.Entities;
using BlogProjectOnion.Domain.Enums;
using BlogProjectOnion.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BlogProjectOnion.Application.Services.Concrete
{
	public class PostService : IPostService
	{
		private readonly IUnıtOfWork _unıtOfWork;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;
		private readonly IMapper _mapper;
		private readonly IImageHelper _imageHelper;

		public PostService(IUnıtOfWork unıtOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, IImageHelper imageHelper)
		{
			_unıtOfWork = unıtOfWork;
			_httpContextAccessor = httpContextAccessor;
			_user = httpContextAccessor.HttpContext.User;
			_mapper = mapper;
			_imageHelper = imageHelper;
		}
		public async Task CreatePostAsync(PostAddDto postAddDto)
		{
			var map = _mapper.Map<Post>(postAddDto);
			var userID = _user.GetLoggedInUserId();
			var imageUpload = await _imageHelper.Upload(postAddDto.Title, postAddDto.Photo, ImageType.Post);
			Image image = new(imageUpload.FullName, postAddDto.Photo.ContentType);
			await _unıtOfWork.GetRepository<Image>().CreateAsync(image);
			map.Image = image;
			map.UserID= userID;
			await _unıtOfWork.GetRepository<Post>().CreateAsync(map);
			await _unıtOfWork.SaveAsync();
		}

		public Task CreatePostWithoutImageAsync(PostAddDto postAddDto)
		{
			throw new NotImplementedException();
		}

		public async Task<PostListDto> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			pageSize = pageSize > 20 ? 20 : pageSize;
			var articles = categoryId == null
				? await _unıtOfWork.GetRepository<Post>().GetAllAsync(a => a.Status != Status.Passive,
				a => a.Genre, i => i.Image, u => u.User)
				: await _unıtOfWork.GetRepository<Post>().GetAllAsync(a => a.GenreID == categoryId && a.Status != Status.Passive,
					a => a.Genre, i => i.Image, u => u.User);
			var sortedArticles = isAscending
				? articles.OrderBy(a => a.CreateDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
				: articles.OrderByDescending(a => a.CreateDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

			return new PostListDto
			{
				Posts = sortedArticles,
				CategoryID = categoryId == null ? null : categoryId.Value,
				CurrentPage = currentPage,
				PageSize = pageSize,
				TotalCount = articles.Count,
				IsAscending = isAscending

			};
		}

		public async Task<List<PostDto>> GetAllPostsDeletedAsync()
		{
			var experiences = await _unıtOfWork.GetRepository<Post>().GetAllAsync(x => x.Status == Domain.Enums.Status.Passive);
			var map = _mapper.Map<List<PostDto>>(experiences);
			return map;
		}

		public async Task<List<PostDto>> GetAllPostsNonDeletedAsync()
		{
			var experiences = await _unıtOfWork.GetRepository<Post>().GetAllAsync(x => x.Status == Domain.Enums.Status.Active);
			var map = _mapper.Map<List<PostDto>>(experiences);
			return map;
		}

		public async Task<PostDto> GetArticleDetailAsync(int articleId)
		{
			var article = await _unıtOfWork.GetRepository<Post>().GetAsync(x => x.PostID == articleId, x => x.User);
			if (article == null)
			{
				return null;
			}

			return await GetPostWithCategoryNonDeletedAsync(articleId);
		}


		public async Task<PostDto> GetPostNonDeletedAsync(int postID)
		{
			var experiences = await _unıtOfWork.GetRepository<Post>().GetAsync(x => x.Status == Domain.Enums.Status.Active && x.PostID == postID);
			var map = _mapper.Map<PostDto>(experiences);
			return map;
		}

		public async Task<PostDto> GetPostWithCategoryNonDeletedAsync(int postID)
		{
			var articles = await _unıtOfWork.GetRepository<Post>().GetAsync(x => x.Status != Domain.Enums.Status.Passive && x.PostID == postID, x => x.Genre, x => x.Image);
			var map = _mapper.Map<PostDto>(articles);
			return map;
		}

		public async Task<string> SafeDeletePostAsync(int postID)
		{
			var experience = await _unıtOfWork.GetRepository<Genre>().GetByIDAsync(postID);
			experience.Status = Domain.Enums.Status.Passive;
			await _unıtOfWork.GetRepository<Genre>().DeleteAsync(experience);
			await _unıtOfWork.SaveAsync();

			return experience.Name;
		}

		public async Task<PostListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			pageSize = pageSize > 20 ? 20 : pageSize;
			var articles = await _unıtOfWork.GetRepository<Post>().GetAllAsync(
				a => a.Status != Domain.Enums.Status.Passive && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Genre.Name.Contains(keyword)),
			a => a.Genre, i => i.Image, u => u.User);

			var sortedArticles = isAscending
				? articles.OrderBy(a => a.CreateDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
				: articles.OrderByDescending(a => a.CreateDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

			return new PostListDto
			{
				Posts = sortedArticles,
				CurrentPage = currentPage,
				PageSize = pageSize,
				TotalCount = articles.Count,
				IsAscending = isAscending
			};
		}

		public async Task<string> UndoDeletePostAsync(int postID)
		{
			var experience = await _unıtOfWork.GetRepository<Genre>().GetByIDAsync(postID);
			experience.Status = Domain.Enums.Status.Active;
			await _unıtOfWork.GetRepository<Genre>().DeleteAsync(experience);
			await _unıtOfWork.SaveAsync();

			return experience.Name;
		}

		public async Task<string> UpdatePostAsync(PostUpdateDto postUpdateDto)
		{
			var experience = await _unıtOfWork.GetRepository<Post>().GetAsync(x => x.Status == Domain.Enums.Status.Active && x.PostID == postUpdateDto.PostID);

			var map = _mapper.Map(postUpdateDto, experience);

			experience.Status = Domain.Enums.Status.Modified;
			await _unıtOfWork.GetRepository<Post>().UpdateAsync(experience);
			await _unıtOfWork.SaveAsync();

			return experience.Title;
		}
	}
}

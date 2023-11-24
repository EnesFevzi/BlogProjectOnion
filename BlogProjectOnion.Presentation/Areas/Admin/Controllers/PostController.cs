using AutoMapper;
using BlogProjectOnion.Application.DTOs.PostDTOs;
using BlogProjectOnion.Application.ResultMessages;
using BlogProjectOnion.Application.Services.Abstract;
using BlogProjectOnion.Domain.Entities;
using BlogProjectOnion.Presentation.Consts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BlogProjectOnion.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<Post> _validator;
        private readonly IValidator<PostAddDto> _addvalidator;

        public PostController(IPostService postService, IMapper mapper, IToastNotification toastNotification, IValidator<Post> validator, IValidator<PostAddDto> addvalidator, IGenreService genreService)
        {
            _postService = postService;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _validator = validator;
            _addvalidator = addvalidator;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            var portfolios = await _postService.GetAllPostsNonDeletedAsync();
            return View(portfolios);
        }
        public async Task<IActionResult> DeletedPost()
        {
            var articles = await _postService.GetAllPostsDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var genres = await _genreService.GetAllGenresNonDeletedAsync();
            return View(new PostAddDto { Genres = genres });
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostAddDto postAddDto)
        {
            var map = _mapper.Map<Post>(postAddDto);
            var result = await _validator.ValidateAsync(map);
            var result2 = await _addvalidator.ValidateAsync(postAddDto);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);


            }
            if (!result2.IsValid)
            {
                result2.AddToModelState(this.ModelState);

            }
            else
            {
                await _postService.CreatePostAsync(postAddDto);
                _toastNotification.AddSuccessToastMessage(Messages.Post.Add(postAddDto.Title), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Post", new { Area = "Admin" });
            }

            var genres = await _genreService.GetAllGenresNonDeletedAsync();
            return View(new PostAddDto { Genres = genres });


        }
        [HttpGet]
        public async Task<IActionResult> Update(int articleId)
        {
            var article = await _postService.GetPostWithCategoryNonDeletedAsync(articleId);
            var genres = await _genreService.GetAllGenresNonDeletedAsync();

            var articleUpdateDto = _mapper.Map<PostUpdateDto>(article);
            articleUpdateDto.Genres = genres;

            return View(articleUpdateDto);
        }
        [HttpPost]
     
        public async Task<IActionResult> Update(PostUpdateDto articleUpdateDto)
        {
            var map = _mapper.Map<Post>(articleUpdateDto);
            var result = await _validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

            }
            else
            {
                var title = await _postService.UpdatePostAsync(articleUpdateDto);
                _toastNotification.AddSuccessToastMessage(Messages.Post.Update(title), new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }


            var genres = await _genreService.GetAllGenresNonDeletedAsync();
            articleUpdateDto.Genres = genres;
            return View(articleUpdateDto);
        }
    }
}

using AutoMapper;
using BlogProjectOnion.Application.DTOs.PostDTOs;
using BlogProjectOnion.Application.Services.Abstract;
using BlogProjectOnion.Infrastructure.UnitOfWorks;
using BlogProjectOnion.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogProjectOnion.Presentation.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IPostService _postService;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IUnıtOfWork _unıtOfWork;

		public HomeController(ILogger<HomeController> logger, IPostService postService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnıtOfWork unıtOfWork)
		{
			_logger = logger;
			_postService = postService;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
			_unıtOfWork = unıtOfWork;
		}
		[HttpGet]
		public async Task<IActionResult> Index(int? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			var articles = await _postService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);
			return View(articles);
		}

		[HttpGet]
		public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			var articles = await _postService.SearchAsync(keyword, currentPage, pageSize, isAscending);
			return View(articles);
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public async Task<IActionResult> Detail(int id)
		{
			var articleDetail = await _postService.GetArticleDetailAsync(id);
			//articleDetail.ViewCount++;
			//var map = _mapper.Map<PostUpdateDto>(articleDetail);
			//await _postService.UpdatePostAsync(map);
			if (articleDetail == null)
			{
				return NotFound();
			}

			return View(articleDetail);
		}
	}
}
using AutoMapper;
using BlogProjectOnion.Application.DTOs.GenreDTOs;
using BlogProjectOnion.Application.Extensions;
using BlogProjectOnion.Application.ResultMessages;
using BlogProjectOnion.Application.Services.Abstract;
using BlogProjectOnion.Domain.Entities;
using BlogProjectOnion.Presentation.Consts;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BlogProjectOnion.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<Genre> _validator;

        public GenreController(IGenreService genreService, IMapper mapper, IToastNotification toastNotification, IValidator<Genre> validator)
        {
            _genreService = genreService;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var genres = await _genreService.GetAllGenresNonDeletedAsync();
            return View(genres);
        }
        public async Task<IActionResult> DeletedGenre()
        {
            var genres = await _genreService.GetAllGenresDeletedAsync();
            return View(genres);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(GenreAddDto genreAddDto)
        {
            var map = _mapper.Map<Genre>(genreAddDto);
            var result = await _validator.ValidateAsync(map);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

            }
            else
            {
                await _genreService.CreateGenreAsync(genreAddDto);
                _toastNotification.AddSuccessToastMessage(Messages.Genre.Add(genreAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Genre", new { Area = "Admin" });
            }

            return View();

        }
        public async Task<IActionResult> Update(int genreId)
        {
            var genre = await _genreService.GetGenreNonDeletedAsync(genreId);
            var articleUpdateDto = _mapper.Map<GenreUpdateDto>(genre);
            return View(articleUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(GenreUpdateDto genreUpdateDto)
        {
            var map = _mapper.Map<Genre>(genreUpdateDto);
            var result = await _validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

            }
            else
            {
                var title = await _genreService.UpdateGenreAsync(genreUpdateDto);
                _toastNotification.AddSuccessToastMessage(Messages.Genre.Update(title), new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Genre", new { Area = "Admin" });
            }

            return View(genreUpdateDto);

        }
        public async Task<IActionResult> Delete(int genreId)
        {
            var title = await _genreService.SafeDeleteGenreAsync(genreId);
            _toastNotification.AddSuccessToastMessage(Messages.Genre.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Genre", new { Area = "Admin" });
        }

        public async Task<IActionResult> UndoDelete(int genreId)
        {
            var title = await _genreService.UndoDeleteGenreAsync(genreId);
            _toastNotification.AddSuccessToastMessage(Messages.Genre.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Genre", new { Area = "Admin" });
        }
    }
}

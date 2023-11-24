using AutoMapper;
using BlogProjectOnion.Application.DTOs.AppUserDto;
using BlogProjectOnion.Application.DTOs.PostDTOs;
using BlogProjectOnion.Application.ResultMessages;
using BlogProjectOnion.Application.VMs;
using BlogProjectOnion.Domain.Entities;
using BlogProjectOnion.Presentation.Consts;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BlogProjectOnion.Presentation.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUserDto> _loginValidator;
        private readonly IToastNotification _toastNotification;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IValidator<CreateUserDto> loginValidator, IToastNotification toastNotification)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _mapper = mapper;
            _loginValidator = loginValidator;
            _toastNotification = toastNotification;
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginDto.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
                    if (result.Succeeded)
                    {
                        var roles = await userManager.GetRolesAsync(user);
                        if (roles.Contains(RoleConsts.Author))
                        {
                            return RedirectToAction("Index", "Dashboard" , new { Area = "Admin" });
                        }
                        if (roles.Contains(RoleConsts.User))
                        {
							return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
						}
                    }
                    else
                    {
                        _toastNotification.AddErrorToastMessage("E-posta adresiniz veya şifreniz yanlıştır.", new ToastrOptions { Title = "İşlem Başarısız" });
                        ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                        return View();
                    }
                }
                else
                {
                    _toastNotification.AddErrorToastMessage("E-posta adresiniz veya şifreniz yanlıştır.", new ToastrOptions { Title = "İşlem Başarısız" });
                    ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                    return View();
                }
            }
            else
            {
                _toastNotification.AddErrorToastMessage("E-posta adresiniz veya şifreniz yanlıştır.", new ToastrOptions { Title = "İşlem Başarısız" });
                ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                return View();
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            var validator = await _loginValidator.ValidateAsync(createUserDto);
            if (!validator.IsValid)
            {
                return View();
            }

            if (createUserDto.Password != createUserDto.ConfirmPassword)
            {
                ModelState.AddModelError("", "Şifreler uyuşmuyor.");
                return View();
            }
            if (createUserDto.Password == createUserDto.ConfirmPassword)
            {
                var appUser = _mapper.Map<AppUser>(createUserDto);
                appUser.UserName = createUserDto.EMail;
                var result = await userManager.CreateAsync(appUser, createUserDto.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, RoleConsts.User);
                    return RedirectToAction("Login", "Auth");
                }

                ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth", new { Area = " " });
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Error404()
        {
            return View();
        }
    }
}

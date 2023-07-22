using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOLayer.DTOS.AppUserDTOS;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDTO appUserRegisterDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDTO.Username,
                    Name = appUserRegisterDTO.Name,
                    Surname = appUserRegisterDTO.Surname,
                    Email = appUserRegisterDTO.Email,
                    City = "İstanbul",
                    District="Pendik",
                    ImageURL="deneme"
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDTO.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View();
        }
    }
}


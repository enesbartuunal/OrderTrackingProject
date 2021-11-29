using System;
using System.Security.Claims;
using _05_MvcWebUI.Entities;
using _05_MvcWebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _05_MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;

        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email
                };

                IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;

                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("User").Result)
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "User"
                        };

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We can't add the role!");
                            return View(registerViewModel);
                        }
                    }
                    _userManager.AddToRoleAsync(user, "User").Wait();
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(registerViewModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false).Result;

                    if (result.Succeeded)
                    {
                        if (User.IsInRole("Admin"))
                        {
                            return RedirectToAction("Restaurants", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Restaurant");
                        }

                    }
                    ModelState.AddModelError("", "Invalid login!");
                }
                return View(loginViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }
    }
}

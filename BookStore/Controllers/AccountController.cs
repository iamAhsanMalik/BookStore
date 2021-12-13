using BookStore.Models;
using BookStore.Repository;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {

            _accountRepository = accountRepository;

        }
        [HttpGet]
        [AllowAnonymous]

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUser(signUpModel);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(SignUp));

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                ModelState.Clear();
            }
            return View();
        }
        [Route("login")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(SignInViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.Login(loginModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Credential");
            }
            return View(loginModel);

        }
        public async Task LogOut()
        {
            await _accountRepository.LogOut();

        }
    }

}

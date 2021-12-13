using BookStore.Models;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUser(SignUpViewModel signUpModel)
        {
            var user = new ApplicationUser() {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName,
                Email = signUpModel.Email,
                UserName = signUpModel.Email
            };
            var result = await _userManager.CreateAsync(user, signUpModel.Password);
            return result;
        }

        public async Task<SignInResult> Login(SignInViewModel loginModel)
        {
            return await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, lockoutOnFailure: true);
        }
        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

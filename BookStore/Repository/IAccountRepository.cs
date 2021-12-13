using BookStore.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUser(SignUpViewModel signUpModel);
        Task<SignInResult> Login(SignInViewModel loginModel);
        Task LogOut();

    }
}

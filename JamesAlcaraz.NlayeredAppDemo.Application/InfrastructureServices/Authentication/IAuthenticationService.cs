using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;

namespace JamesAlcaraz.NlayeredAppDemo.Application.InfrastructureServices.Authentication
{
    public interface IAuthenticationService
    {
        Task<UserRegistrationResult> RegisterUser(UserRegistrationInput userModel);
        Task<SignInResult> SignIn(string userName, string password);
    }
}

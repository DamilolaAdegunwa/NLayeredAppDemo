using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Application.InfrastructureServices.Authentication;
using JamesAlcaraz.NlayeredAppDemo.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using JamesAlcaraz.NlayeredAppDemo.WebApi.App_Start;

namespace JamesAlcaraz.NlayeredAppDemo.WebApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationService(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }


        public async Task<UserRegistrationResult> RegisterUser(UserRegistrationInput userModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userModel.Email,
                Email = userModel.Email
            };

            var identityResult = await _userManager.CreateAsync(user, userModel.Password);

            if (identityResult != null)
            {
                return identityResult.Succeeded
                    ? new UserRegistrationResult(succeeded:true)
                    : new UserRegistrationResult(identityResult.Errors);
            }

            return new UserRegistrationResult(succeeded:false);
        }

        public async Task<SignInResult> SignIn(string userName, string password)
        {
            IdentityUser identityUser = await _userManager.FindAsync(userName, password);

            if (identityUser != null)
                return new SignInResult(success:true);

            return null;
        }


    }
}
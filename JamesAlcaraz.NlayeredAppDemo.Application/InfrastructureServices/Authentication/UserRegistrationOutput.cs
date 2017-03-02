using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesAlcaraz.NlayeredAppDemo.Application.InfrastructureServices.Authentication
{
    public class UserRegistrationResult
    {
        public UserRegistrationResult(bool succeeded)
        {
            Succeeded = succeeded;
        }
        public UserRegistrationResult(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        //public UserRegistrationInput UserRegistrationInput { get; set; }
        public bool Succeeded { get; private set; }
        public IEnumerable<string> Errors { get; private set; }
    }
}

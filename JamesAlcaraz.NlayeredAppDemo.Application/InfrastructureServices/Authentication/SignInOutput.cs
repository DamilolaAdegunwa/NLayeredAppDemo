using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesAlcaraz.NlayeredAppDemo.Application.InfrastructureServices.Authentication
{
    public class SignInResult
    {
        public SignInResult(bool success)
        {
            Success = success;
        }
        public bool Success { get; set; }
    }
}

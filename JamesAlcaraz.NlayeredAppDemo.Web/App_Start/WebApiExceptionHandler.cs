using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace JamesAlcaraz.NlayeredAppDemo.Web.App_Start
{
    public class WebApiExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            //TODO: Exception logging and format response message
            base.Handle(context);
        }
    }
}
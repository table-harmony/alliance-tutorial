using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ErrorHandlingTutorial {
    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {

        }

        protected void Session_Start(object sender, EventArgs e) {

        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {
            Exception exception = Server.GetLastError();
            Server.ClearError();

            if (exception == null)
                return;

            // Handle 404 errors
            if (exception is HttpException httpException
                && httpException.GetHttpCode() == 404) {
                Server.Transfer("~/404.aspx");
                return;
            }

            // Unwrap the original exception if it's a HttpUnhandledException
            if (exception is HttpUnhandledException unhandledHttpException
                && unhandledHttpException.InnerException != null) {
                exception = unhandledHttpException.InnerException;
            }

            HttpContext.Current.Items["Exception"] = exception;
            Server.Transfer("~/500.aspx");
        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}
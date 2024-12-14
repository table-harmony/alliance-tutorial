using FileUploaderTutorial.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FileUploaderTutorial {
    public class Global : System.Web.HttpApplication {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected void Application_Start(object sender, EventArgs e) {
            var services = new ServiceCollection();
            services.AddScoped<IFileUploader, LocalFileUploader>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected void Session_Start(object sender, EventArgs e) {

        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {

        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}
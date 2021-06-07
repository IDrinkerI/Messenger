using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;


namespace Messenger.Api
{
    public static class AuthenticationSetupExtension
    {
        public static void AuthenticationSetup(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Events.OnRedirectToLogin = context => Task.CompletedTask;
                    options.Events.OnRedirectToAccessDenied = context => Task.CompletedTask;
                    options.Events.OnRedirectToLogout = context => Task.CompletedTask;
                    options.Events.OnRedirectToReturnUrl = context => Task.CompletedTask;
                });
        }
    }
}

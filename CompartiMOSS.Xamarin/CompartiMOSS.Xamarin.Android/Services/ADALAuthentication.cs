using CompartiMOSS.Xamarin.Models;
using CompartiMOSS.Xamarin.Services.Authentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Plugin.CurrentActivity;
using System;
using System.Linq;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(CompartiMOSS.Xamarin.Droid.Services.ADALAuthenticator))]
namespace CompartiMOSS.Xamarin.Droid.Services
{
    public class ADALAuthenticator : IADALAuthenticator
    {
        private const string TenantUrl = "https://login.microsoftonline.com/common";
        public static string ADClientId = "Your Application ID Azure AD Native Appications";
        public static string tenant = "Your Tenant ID";
        public static Uri returnUriId = new Uri("Your return id Azure AD Native Application");
        public static string WebApiADClientId = "Your Application ID Azure AD WebAPI application";

        public async Task<ADToken> AuthenticationAsync()
        {
            try
            {
                var platformParams = new PlatformParameters(CrossCurrentActivity.Current.Activity);
                var authContext = new AuthenticationContext(TenantUrl);

                if (authContext.TokenCache.ReadItems().Any())
                {
                    authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().FirstOrDefault().Authority);
                }

                var authResult = await authContext.AcquireTokenAsync(WebApiADClientId, ADClientId, returnUriId, platformParams);

                return new ADToken()
                {
                    AccessToken = authResult.AccessToken,
                    TokenType = authResult.AccessTokenType,
                    Expires = authResult.ExpiresOn.Ticks,
                    UserName = authResult.UserInfo.DisplayableId
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

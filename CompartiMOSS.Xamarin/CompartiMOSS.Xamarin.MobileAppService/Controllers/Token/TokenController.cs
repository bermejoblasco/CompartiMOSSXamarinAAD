using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace CompartiMOSS.Xamarin.MobileAppService.Controllers.Token
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration adSettings;

        public TokenController(IConfiguration adSettings)
        {
            this.adSettings = adSettings;
        }

        /// <summary>
        /// Get Azure AD Token,use only works in test enviroment for swagger
        /// </summary>
        /// <returns>Bearer token </returns>
        [HttpGet("GetToken")]
        public async Task<string> GetToken()
        {
            try
            {
                var clientId = this.adSettings.GetSection("AzureAd:ClientId").Value;
                var secretId = this.adSettings.GetSection("AzureAd:ClientSecret").Value;
                var instace = this.adSettings.GetSection("AzureAd:Instance").Value;
                //var domain = this.adSettings.GetSection("AzureAd:Domain").Value;
                var domain = this.adSettings.GetSection("AzureAd:TenantId").Value;

                var clientCredential = new ClientCredential(clientId, secretId);
                AuthenticationContext context = new AuthenticationContext(instace + domain, false);
                AuthenticationResult authenticationResult = await context.AcquireTokenAsync(
                    clientId,  // the resource (app) we are going to access with the token
                    clientCredential);  // the client credentials
                return $"Bearer { authenticationResult.AccessToken}";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private async Task<NameValueCollection> CreateParameters()
        {
            var clientId = this.adSettings.GetSection("AzureAd:ClientId").Value;
            var secretId = this.adSettings.GetSection("AzureAd:ClientSecret").Value;
            var instace = this.adSettings.GetSection("AzureAd:Instance").Value;
            var domain = this.adSettings.GetSection("AzureAd:Domain").Value;
            var userName = this.adSettings.GetSection("UserLoginAD:username").Value;
            var password = this.adSettings.GetSection("UserLoginAD:key").Value;

            var parameters = new NameValueCollection();

            parameters.Add("resource", clientId);
            parameters.Add("client_id", clientId);
            parameters.Add("grant_type", "password");
            parameters.Add("username", userName);
            parameters.Add("password", password);
            parameters.Add("scope", "openid");
            parameters.Add("client_secret", secretId);

            return parameters;
        }


    }

    public class ADToken
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public long Expires { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        public override string ToString()
        {
            return $"{TokenType} {AccessToken}";
        }
    }
}

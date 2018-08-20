namespace CompartiMOSS.Xamarin.Models
{
    using Newtonsoft.Json;

    public class ADToken
    {        
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public long Expires { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        public string UserName { get; set; }

        public override string ToString()
        {
            return $"{TokenType} {AccessToken}";
        }
    }
}

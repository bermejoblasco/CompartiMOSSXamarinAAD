using CompartiMOSS.Xamarin.Models;
using System.Threading.Tasks;

namespace CompartiMOSS.Xamarin.Services.Authentication
{
    public interface IADALAuthenticator
    {
        Task<ADToken> AuthenticationAsync();
    }
}

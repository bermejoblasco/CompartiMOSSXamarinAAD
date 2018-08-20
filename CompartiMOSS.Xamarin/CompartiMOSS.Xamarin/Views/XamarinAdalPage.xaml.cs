using CompartiMOSS.Xamarin.Services.Authentication;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CompartiMOSS.Xamarin.Views
{
    public partial class XamarinAdalPage : ContentPage
    {
        public XamarinAdalPage()
        {
            InitializeComponent();
        }

        async void Login_Clicked(object sender, System.EventArgs e)
        {
            await LoginAsync();
        }
        private async Task LoginAsync()
        {
            var response = await DependencyService.Get<IADALAuthenticator>().AuthenticationAsync();

            if (response != null)
            {
                App.BearerToken = response.AccessToken;
                await Navigation.PushModalAsync(new MainPage());
            }
        }
    }
}
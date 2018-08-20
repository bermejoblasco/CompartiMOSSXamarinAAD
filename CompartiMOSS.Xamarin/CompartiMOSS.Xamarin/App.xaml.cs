using CompartiMOSS.Xamarin.Services;
using CompartiMOSS.Xamarin.Services.Authentication;
using CompartiMOSS.Xamarin.Views;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CompartiMOSS.Xamarin
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "*.azurewebsites.net";
        public static bool UseMockDataStore = false;
        public static string BearerToken = string.Empty;

        public App()
        {
            InitializeComponent();            

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<AzureDataStore>();

            MainPage = new XamarinAdalPage();
        }
       


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

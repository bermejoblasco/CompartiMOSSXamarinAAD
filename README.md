# CompartiMOSSXamarinAAD
Código del articulo del número 37 de CompartiMOSS http://www.compartimoss.com/revistas/numero-37/autenticando-xamarin-forms-con-azure-ad

Para ejecutar el código debeis seguir el aritculo de CompartiMOSS del número 37 (añadir link)

Para hacer que funcinoes hay que cambiar las siguientes lineas:
* En CompartiMOSS.Xamarin --> App.cs cambiar:

        public static string AzureBackendUrl = "*.azurewebsites.net"; por la URL de la web app de azure donde despliegues la API.
* En CompartiMOSS.Xamarin.Drod.Services cambiar:

        public static string ADClientId = "Your Application ID Azure AD Native Appications";
        public static string tenant = "Your Tenant ID";
        public static Uri returnUriId = new Uri("Your return id Azure AD Native Application");
        public static string WebApiADClientId = "Your Application ID Azure AD WebAPI application";
        
Por los valores correspondientes.
* En CompartiMOSS.Xamarin.MobileAppService en appSettings.json camibar:

   "ClientId": "Your application Id azure ad web api applications",
   
    "ClientSecret": "Your secret key Id azure ad web api applications",
    
    "TenantId": "Your Azure Tenant ID",
    
    "AppIDURL": "Your AppIDRUI azure ad web api application",
    
Por los valores correspondientes.

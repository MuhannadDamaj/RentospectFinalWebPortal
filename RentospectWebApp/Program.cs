using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;
using RentospectWebApp.API;
using RentospectWebApp;
using RentospectWebApp.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthStateProvider>();
builder.Services.AddSingleton<AuthenticationStateProvider>(sp => sp.GetRequiredService<AuthStateProvider>());
builder.Services.AddAuthorizationCore();
ConfigureRefit(builder.Services, apiBaseUrl);

await builder.Build().RunAsync();


static void ConfigureRefit(IServiceCollection services, string apiBaseUrl)
{
    services.AddRefitClient<IAuthApi>().ConfigureHttpClient(
        httpClient => SetHttpClient(httpClient, apiBaseUrl)
    );
    services.AddRefitClient<ICurrencyApi>(
       sp => GetRefitSettings(sp)
   ).ConfigureHttpClient(
       httpClient => SetHttpClient(httpClient, apiBaseUrl)
   );
    services.AddRefitClient<ICompanyApi>(
       sp => GetRefitSettings(sp)
   ).ConfigureHttpClient(
       httpClient => SetHttpClient(httpClient, apiBaseUrl)
   );
    services.AddRefitClient<IBranchApi>(
       sp => GetRefitSettings(sp)
   ).ConfigureHttpClient(
       httpClient => SetHttpClient(httpClient, apiBaseUrl)
   );
    services.AddRefitClient<IUserApi>(
       sp => GetRefitSettings(sp)
   ).ConfigureHttpClient(
       httpClient => SetHttpClient(httpClient, apiBaseUrl)
   );
    services.AddRefitClient<ICarClassApi>(
       sp => GetRefitSettings(sp)
   ).ConfigureHttpClient(
       httpClient => SetHttpClient(httpClient, apiBaseUrl)
   );
    services.AddRefitClient<ICarCategoryApi>(
       sp => GetRefitSettings(sp)
   ).ConfigureHttpClient(
       httpClient => SetHttpClient(httpClient, apiBaseUrl)
   );
    services.AddRefitClient<ICarModelApi>(
       sp => GetRefitSettings(sp)
   ).ConfigureHttpClient(
       httpClient => SetHttpClient(httpClient, apiBaseUrl)
   );
    services.AddRefitClient<ICarMakeApi>(
       sp => GetRefitSettings(sp)
   ).ConfigureHttpClient(
       httpClient => SetHttpClient(httpClient, apiBaseUrl)
   );
    services.AddRefitClient<ICarApi>(
       sp => GetRefitSettings(sp)
   ).ConfigureHttpClient(
       httpClient => SetHttpClient(httpClient, apiBaseUrl)
   );
    services.AddRefitClient<IDamageApi>(
       sp => GetRefitSettings(sp)
   ).ConfigureHttpClient(
       httpClient => SetHttpClient(httpClient, apiBaseUrl)
   );
    services.AddRefitClient<IUploadImage>(
       sp => GetRefitSettings(sp)
   ).ConfigureHttpClient(
       httpClient => SetHttpClient(httpClient, apiBaseUrl)
   );
    services.AddRefitClient<ICarClassDamageApi>(
      sp => GetRefitSettings(sp)
  ).ConfigureHttpClient(
      httpClient => SetHttpClient(httpClient, apiBaseUrl)
  );
    services.AddRefitClient<IUploadApi>(
      sp => GetRefitSettings(sp)
  ).ConfigureHttpClient(
      httpClient => SetHttpClient(httpClient, apiBaseUrl)
  );
    static void SetHttpClient(HttpClient httpClient, string apiBaseUrl) =>
        httpClient.BaseAddress = new Uri(apiBaseUrl);
    static RefitSettings GetRefitSettings(IServiceProvider sp)
    {
        var authStateProvider = sp.GetRequiredService<AuthStateProvider>();
        return new RefitSettings
        {
            AuthorizationHeaderValueGetter = (_, __) =>
                Task.FromResult(authStateProvider._user?.Token ?? "")
        };
    }
}

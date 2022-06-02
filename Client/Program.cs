using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAuthIssue.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BlazorAuthIssue.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorAuthIssue.ServerAPI"));

builder.Services.AddOidcAuthentication(options =>
{
    var providerOptions = options.ProviderOptions;
    providerOptions.Authority = "https://www.theidserver.com/";
    providerOptions.ClientId = "blazorissueclient";
    providerOptions.ResponseType = "code";
    providerOptions.DefaultScopes.Add("blazorissueapi");
    builder.Configuration.Bind(nameof(options.UserOptions), options.UserOptions);
}).AddAccountClaimsPrincipalFactory<ClaimsPrincipalFactory>(); ;

builder.Services.AddAuthorizationCore(options => options.AddPolicy("Reader", policy => policy.RequireRole("BlazorIssue-Reader")));

await builder.Build().RunAsync();

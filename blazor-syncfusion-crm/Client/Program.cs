using BlazorSyncfusionCmr.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BlazorSyncfusionCmr.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorSyncfusionCmr.ServerAPI"));

builder.Services.AddSyncfusionBlazor();

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqVk1hXk5Hd0BLVGpAblJ3T2ZQdVt5ZDU7a15RRnVfR1xlSHhQcEFrUH1ccg==;Mgo+DSMBPh8sVXJ1S0R+X1pFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jTH9Vd0NgX3tXcHdWRQ==;ORg4AjUWIQA/Gnt2VFhiQlJPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtScERlWnlaeXRcQGM=;MjA3OTczOUAzMjMxMmUzMjJlMzNseDVmSUVRUHBSMWhueENRRSt1RHlmL1FVQ2dNR01uNGFBRjZBRFdDSjlNPQ==;MjA3OTc0MEAzMjMxMmUzMjJlMzNUYXN2dVdndXQ0bkFnVWRiUytNcENYdU1xZGJjcEM5TWppZWJMZ0VPRU9RPQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Wd0NiX3xYdH1UTmFf;MjA3OTc0MkAzMjMxMmUzMjJlMzNPbXcxNUJtUTVidGhkeGkzQ1pFVGoyYUkzT1MwdjIwM2hPQzRIVFl2RW1VPQ==;MjA3OTc0M0AzMjMxMmUzMjJlMzNpR3U1SEF6ajlNelo4VG9XSWF1YzFLQ1VaYnptVUZjUU1JbkxiUzRRTHd3PQ==;Mgo+DSMBMAY9C3t2VFhiQlJPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtScERlWnlaeXZQQGE=;MjA3OTc0NUAzMjMxMmUzMjJlMzNaQmQ2U3NTd3FYcTIrNFdnZGJqWllCbGMvTW5VNExJUzFJMDBnUmw3OVdzPQ==;MjA3OTc0NkAzMjMxMmUzMjJlMzNGMkMrVitpZ3JxaVVJbjlyT1Y4TmdVRnBpYzBVdlZwYWJyaDY3aDZqdG9nPQ==;MjA3OTc0N0AzMjMxMmUzMjJlMzNPbXcxNUJtUTVidGhkeGkzQ1pFVGoyYUkzT1MwdjIwM2hPQzRIVFl2RW1VPQ==");

await builder.Build().RunAsync();

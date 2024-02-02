using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Routing;

namespace Server;

[ApiVersion("1.0")]
[ApiController]
[VersionedDeliveryApiRoute(Umbraco.Cms.Api.Common.Security.Paths.MemberApi.EndpointTemplate)]
[ApiExplorerSettings(IgnoreApi = true)]
public class ExternalMemberController : Controller
{   
    [HttpGet("signout-external")]
    public IActionResult SignOutExternal()
    {   
        // Trigger logout on the external login provider.
        return SignOut("UmbracoMembers.OpenIdConnect");
    }
}

internal sealed class VersionedDeliveryApiRouteAttribute : BackOfficeRouteAttribute
{
    public VersionedDeliveryApiRouteAttribute(string template)
        : base($"delivery/api/v{{version:apiVersion}}/{template.TrimStart('/')}")
    {
    }
}
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ServiceHub.Tests.Helpers;

public static class FakeHttpContext
{
    public static IHttpContextAccessor CriarHttpContextFake()
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity(
            new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "905d2566-1c40-4d38-9a65-03835a49975b")
            },
            "mock"));

        var context = new DefaultHttpContext();
        context.User = user;

        var accessor = new HttpContextAccessor();
        accessor.HttpContext = context;

        return accessor;
    }
}
using System.Security.Claims;

namespace ZephyrBetAPI.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public AuthService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetEmail()
    {
        var result = string.Empty;
        if (_httpContextAccessor.HttpContext is not null)
        {
            if (IsAuthenticated())
            {
                result = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            }
        }

        return result;
    }

    public bool IsAuthenticated()
    {
        if (_httpContextAccessor.HttpContext is not null)
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        return false;
    }

    public int GetUserId()
    {
        if(_httpContextAccessor.HttpContext is not null)
        {
            if (IsAuthenticated())
            {
                return Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid).Value);
            }
        }

        return -1;
    }


}
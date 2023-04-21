namespace ZephyrBetAPI.Services.AuthService;

public interface IAuthService
{
    public string GetEmail();
    public int GetUserId();
    public bool IsAuthenticated();
    
    
    
}
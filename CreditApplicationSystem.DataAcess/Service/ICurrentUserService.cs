namespace CreditApplicationSystem.DataAccess.Service;

public interface ICurrentUserService
{
    string Email { get; set; }
    bool IsAuthenticated { get; set; }
}
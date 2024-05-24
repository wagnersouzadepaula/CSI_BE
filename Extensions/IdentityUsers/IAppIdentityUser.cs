namespace CSI_BE.Extensions.IdentityUsers
{
    public interface IAppIdentityUser
    {
        Guid GetUserId();
        bool IsAuthenticated();
    }
}

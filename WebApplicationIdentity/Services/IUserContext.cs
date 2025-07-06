namespace WebApplicationIdentity.Services
{
    public interface IUserContext
    {
        public CurrentUser? GetCurrentUser();
    }
}

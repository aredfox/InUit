namespace InUit.Model.Users
{
    public interface IUserProvider
    {
        User GetLoggedInUser();
    }
}

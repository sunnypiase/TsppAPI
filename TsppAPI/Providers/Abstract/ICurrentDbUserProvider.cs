namespace TsppAPI.Providers.Abstract
{
    public interface ICurrentDbUserProvider
    {
        string Username { get; }
        string Password { get; }
    }

}

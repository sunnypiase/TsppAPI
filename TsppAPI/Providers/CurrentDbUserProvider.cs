using TsppAPI.Providers.Abstract;

namespace TsppAPI.Providers
{
    public class CurrentDbUserProvider : ICurrentDbUserProvider
    {
        private static readonly Lazy<CurrentDbUserProvider> _instance = new Lazy<CurrentDbUserProvider>(() => new CurrentDbUserProvider());

        public string Username { get; private set; }
        public string Password { get; private set; }

        private CurrentDbUserProvider()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
        public static CurrentDbUserProvider Instance
        {
            get { return _instance.Value; }
        }
        public void SetUserCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }

}

namespace IdentityProvider.IServices
{
    public interface ITokenBuilder
    {
        public string BuildToken(string username);
    }
}

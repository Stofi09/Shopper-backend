namespace WebApplication1.Utilities
{
    public interface ITokenGenerator
    {
        public string GenerateUserToken(string secretKey, int expiryMinutes, string id);
    }
}

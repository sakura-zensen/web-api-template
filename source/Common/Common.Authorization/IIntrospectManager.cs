namespace Common.Authorization
{
    public interface IIntrospectManager
    {
        object ValidateJwtToken(string token);
    }
}
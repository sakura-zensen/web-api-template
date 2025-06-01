namespace Common.Authorization;

public partial class IntrospectManager : IIntrospectManager
{
    public object ValidateJwtToken(string token)
    {
        try
        {
            ValidateTokenAsync(token);
            return new
            {
                isValidUser = true
            };
        }
        catch (Exception ex)
        {
            return new
            {
                isValidUser = false,
                ex.Message
            };
        }
    }
}

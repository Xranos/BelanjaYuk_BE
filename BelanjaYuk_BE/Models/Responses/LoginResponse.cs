namespace BelanjaYuk_BE.Models.Responses
{
    public sealed class LoginResponse
    {
        public LoginResponse()
        {
        }

        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string IdUser { get; set; }
    }
}

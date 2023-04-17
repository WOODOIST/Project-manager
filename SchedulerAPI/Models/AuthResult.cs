namespace ProjectManagerAPI.Models
{
    public class AuthResult
    {
        public string Token { get; set; }
        public string Result { get; set; }
        public List<string> Errors { get; set; }
    }
}

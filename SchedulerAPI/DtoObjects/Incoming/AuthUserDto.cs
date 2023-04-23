using System.Xml.Serialization;

namespace ProjectManagerAPI.DtoObjects.Incoming
{
    public class AuthUserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public string UserMessage { get; set; }
        public string AccessToken { get; set; }
    }
}

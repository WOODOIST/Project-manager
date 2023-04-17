using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.DtoObjects
{
    public class UserModel
    {
        public int Userid { get; set; }

        public string Usersurname { get; set; }

        public string Username { get; set; }

        public string Userpatronymic { get; set; }

        public string Userlogin { get; set; }

        public string Userpassword { get; set; }

        public string Useremail { get; set; }

        public int Roleid { get; set; }

        public string UserMessage { get; set; }
        public string AccessToken { get; set; }

        

    }
}

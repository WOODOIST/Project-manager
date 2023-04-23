using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.DtoObjects.Outgoing
{
    public class UserDto
    {
        public string UserSurname { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string? UserPatronymic { get; set; }

        public string UserEmail { get; set; } = null!;

        public string RoleName { get; set; }


    }
}

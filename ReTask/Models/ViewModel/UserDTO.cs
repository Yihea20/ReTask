using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ReTask.Models.ViewModel
{


    public class LoginUserDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }
    public class UserDTO : LoginUserDTO
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        // public ICollection<string> roleName { get; set; } = new List<string>() { "USER"};
    }

}

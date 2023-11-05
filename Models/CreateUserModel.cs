using System.ComponentModel.DataAnnotations.Schema;

namespace ChatChit.Models
{
    public class CreateUserModel
    {
        public string fullName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}

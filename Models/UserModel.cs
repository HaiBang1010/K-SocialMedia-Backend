using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatChit.Models
{
    public class UserModel
    {
        [Key]
        [Column("id")]
        public Guid id { get; set; }
        [Column("full_name")] 
        public string? fullName { get; set; }

        [Column("email")]
        public string? email { get; set; }
        [Column("image")]
        public string? image { get; set; }
        [Column("nick_name")]
        public string? nickName {  get; set; }
        [Column("password")]
        public string password { get; set; }
        [Column("created_at")]
        public DateTime createdAt { get; set; }
        [Column("updated_at")]
        public DateTime updatedAt { get; set;}
            
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace ChatChit.Models
{
    public class MessageModel
    {
        [Column("id")]
        public string id { get; set; }
        [Column("sender_id")]
        public string senderId { get; set; }
        [Column("receiver_id")]
        public string receiverId { get; set; }
        [Column("content")]
        public string content { get; set; }
        [Column("create_at")]
        public DateTime createAt { get; set; }
        [Column("is_read")]
        public bool isRead { get; set; }
        public UserModel UserSend { get; set; }
        public UserModel UserReceiver { get; set; }
    }
}

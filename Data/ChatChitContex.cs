using ChatChit.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatChit.Data
{
    public class ChatChitContex : DbContext
    {
        public ChatChitContex(DbContextOptions<ChatChitContex> options) : base(options)
        {

        }

        public DbSet<UserModel>? Users { get; set; }
    }
}

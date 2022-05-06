using System;
using System.ComponentModel.DataAnnotations;

namespace PasteBook.WebApi.Models
{
    public class UserFriend
    {
        [Key]
        public int UserFriendId { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }

        public User User { get; set; }
    }
}

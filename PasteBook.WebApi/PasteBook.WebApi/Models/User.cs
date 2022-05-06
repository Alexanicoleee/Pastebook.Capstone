using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PasteBook.WebApi.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<UserFriend> UserFriends { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}

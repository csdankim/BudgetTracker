using System;

namespace ApplicationCore.Models.Request
{
    public class UserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public DateTime? JoinedOn { get; set; }
    }
}
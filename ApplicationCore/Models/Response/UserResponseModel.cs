using System;

namespace ApplicationCore.Models.Response
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public DateTime? JoinedOn { get; set; }
    }
}
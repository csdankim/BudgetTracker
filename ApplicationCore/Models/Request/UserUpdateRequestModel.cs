using System;
using System.Runtime.InteropServices.ComTypes;

namespace ApplicationCore.Models.Request
{
    public class UserUpdateRequestModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public DateTime? JoinedOn { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectPhone.Models
{
    class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }

    }
}

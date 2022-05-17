using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Userprogram
    {
        public string Email { get; set; }
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

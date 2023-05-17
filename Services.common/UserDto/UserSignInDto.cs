using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.common.UserDto
{
    public class UserSignInDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}

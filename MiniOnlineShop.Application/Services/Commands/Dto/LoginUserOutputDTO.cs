using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOnlineShop.Application.Services.Commands.Dto
{
    public class LoginUserOutputDTO
    {
        public long UserId { get; set; }
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOnlineShop.Application.Services.Commands.Dto
{
    public class RegisterUserOutputDTO
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

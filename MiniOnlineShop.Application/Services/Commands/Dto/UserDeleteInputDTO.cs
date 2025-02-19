using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOnlineShop.Application.Services.Commands.Dto
{
    public class UserDeleteInputDTO
    {
        public long Id { get; set; }
        public long RemoveByUserId { get; set; }
    }
}

using MiniOnlineShop.Common.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOnlineShop.Common.BaseInterfaces
{
    public interface IBaseCrudCommandService<TId, TUpdateinputDTO, TDeleteinputDTO>
         where TUpdateinputDTO : class
         where TDeleteinputDTO : class
    {
        Task<ApiResult> Update(TUpdateinputDTO inputDTO);
        Task<ApiResult> Delete(TDeleteinputDTO inputDTO);
        Task <ApiResult> SoftDelete(TDeleteinputDTO inputDTO);
    }
}

using MiniOnlineShop.Common.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOnlineShop.Common.BaseInterfaces
{
    public interface IBaseCrudQueryService<TId, TOutputDTO,TGetAllinputDTO>
        where TOutputDTO : class
        where TGetAllinputDTO : class
    {
        Task<ApiResult<TOutputDTO>> GetAll(TGetAllinputDTO inputDTO);
        Task<ApiResult<TOutputDTO>> Get(TId id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasciFramework.Dommain.Repositorys
{
    /// <summary>
    /// 基础只读仓储接口
    /// </summary>
    public  interface IReadOnlyBaseRepository<T> where T:new ()
    {
        Task<int> Count();

        Task<int> CountAsync();

        Task<IList<T>> GetList();

        Task<IList<T>> GetListAsync();

    }
}

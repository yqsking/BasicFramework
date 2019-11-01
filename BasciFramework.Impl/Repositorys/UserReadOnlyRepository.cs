using BasicFramework.Dommain.Entitys.User;
using BasicFramework.Dommain.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace BasicFramework.Impl.Repositorys
{
    /// <summary>
    /// 用户基础信息只读仓储
    /// </summary>
    public  class UserReadOnlyRepository: ReadOnlyBaseRepository<UserEntity>, IUserReadOnlyRepository
    {
        public UserReadOnlyRepository (DbContext db):base(db)
        {

        }
    }
}

using BasicFramework.Dommain.Entitys.User;

namespace BasicFramework.Dommain.Repositorys
{
    /// <summary>
    /// 用户基础信息只读仓储
    /// </summary>
    public  interface IUserReadOnlyRepository: IReadOnlyBaseRepository<UserEntity>
    {
    }
}

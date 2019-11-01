﻿using BasicFramework.Dommain.Entitys.User;
using BasicFramework.Dommain.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace BasicFramework.Impl.Repositorys
{
    /// <summary>
    /// 用户基础信息仓储
    /// </summary>
    public  class UserRepository:BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DbContext db):base(db)
        {

        }
    }
}
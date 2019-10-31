﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFramework.Dommain.Entitys.User
{
    /// <summary>
    /// 用户基础信息
    /// </summary>
    [Table("t_User_Users")]
    public  class UserEntity:BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(50)]
        public string UserName { get; private set; }

        /// <summary>
        /// 设置用户名
        /// </summary>
        /// <param name="userName"></param>
        public void SetUserName(string userName)
        {
            UserName = userName;
        }

        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; private set; }

        /// <summary>
        /// 设置手机号
        /// </summary>
        /// <param name="phone"></param>
        public void SetPhone(string phone)
        {
            Phone = phone;
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Pwd { get; private set; }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="pwd"></param>
        public void SetPwd(string pwd)
        {
            Pwd = pwd;
        }
    }
}

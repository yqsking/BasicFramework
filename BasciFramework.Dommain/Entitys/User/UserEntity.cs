using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFramework.Dommain.Entitys.User
{
    /// <summary>
    /// 用户基础信息
    /// </summary>
    [Table("t_User_User")]
    public  class UserEntity:BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <param name="photo">用户头像</param>
        public UserEntity(string userName,string phone,string pwd,string photo)
        {
            UserName = userName;
            Phone = phone;
            Pwd = pwd;
            Photo = photo;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(50),Required]
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
        [MaxLength(20),Required]
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
        [MaxLength(10), Required]
        public string Pwd { get; private set; }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="pwd"></param>
        public void SetPwd(string pwd)
        {
            Pwd = pwd;
        }

        /// <summary>
        /// 用户头像
        /// </summary>
        [MaxLength(200)]
        public string Photo { get; private set; }

        /// <summary>
        /// 设置用户头像
        /// </summary>
        /// <param name="photo"></param>
        public void SetPhoto(string photo)
        {
            Photo = photo;
        }

      
    }
}

using BasicFramework.Dommain.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFramework.Dommain.Entitys.UserBasic
{
    /// <summary>
    /// 用户基础信息
    /// </summary>
    [Table("t_user_userBasic")]
    public  class UserBasicEntity:BaseEntity
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <param name="roleType">角色类型</param>
        /// <param name="photo">用户头像</param>
        /// <param name="qqNumber">qq号码</param>
        /// <param name="wecharNumber">微信号</param>
        /// <param name="alipayNumber">支付宝账号</param>
        /// <param name="email">邮箱</param>
        public UserBasicEntity(string name, string phone, string pwd,string roleType, string photo,string qqNumber,
            string wecharNumber,string alipayNumber,string email,string userState)
        {
            this.Name = name;
            this.Phone = phone;
            this.Pwd = pwd;
            this.RoleType = roleType;
            this.Photo = photo;
            this.QQNumber = qqNumber;
            this.WecharNumber = wecharNumber;
            this.AlipayNumber = alipayNumber;
            this.Email = email;
            this.UserState = userState;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(50),Required]
        public string Name { get; private set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(20),Required]
        public string Phone { get; private set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [MaxLength(10), Required]
        public string Pwd { get; private set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        [MaxLength(50),Required]
        public string RoleType { get;private set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        [MaxLength(200)]
        public string Photo { get; private set; }

        /// <summary>
        /// qq号码
        /// </summary>
        [MaxLength(100)]
        public string QQNumber { get; private set; }

        /// <summary>
        /// 微信号码
        /// </summary>
        [MaxLength(100)]
        public string WecharNumber { get;private set; }

        /// <summary>
        /// 支付宝账号
        /// </summary>
        [MaxLength(100)]
        public string AlipayNumber { get; private set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [MaxLength(50)]
        public string Email { get;private set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        [MaxLength(50),Required]
        public string UserState { get; private set; }

        /// <summary>
        /// 设置基础信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="photo"></param>
        /// <param name="qqNumber"></param>
        /// <param name="wecharNumber"></param>
        /// <param name="alipayNumber"></param>
        /// <param name="email"></param>
        public void SetUserBasicInfo(string name,string phone,string photo,string qqNumber,string wecharNumber,string alipayNumber,string email)
        {
            this.Name = name;
            this.Phone = phone;
            this.Photo = photo;
            this.QQNumber = qqNumber;
            this.WecharNumber = wecharNumber;
            this.AlipayNumber = alipayNumber;
            this.Email = email;
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="pwd"></param>
        public void SetPwd(string pwd)
        {
            this.Pwd = pwd;
        }

        /// <summary>
        /// 设置用户状态
        /// </summary>
        /// <param name="userState"></param>
        public void SetUserState(string userState)
        {
            this.UserState = userState;
        }
    }
}

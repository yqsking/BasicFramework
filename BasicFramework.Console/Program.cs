using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace BasicFramework.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<UserInfo> list = new List<UserInfo>()
            {
                new UserInfo { Id=1, UserName="saber",Age=18},new UserInfo { Id=2, UserName="archar",Age=20},new UserInfo { Id=3, UserName="张三",Age=20}
            };
            var temp= list.OrderByDescending(item=>item.Age).ThenBy(item=>item.Id);
           
          
            
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        public class UserInfo
        {
            public int Id { get; set; }

            /// <summary>
            /// 用户名
            /// </summary>
            [Description("用户名")]
            public string UserName { get; set; }

            /// <summary>
            /// 年龄
            /// </summary>
            [Description("年龄")]
            public int Age { get; set; }
        }
    }
}

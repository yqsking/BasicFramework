using BasicFramework.Common.Expands;
using BasicFramework.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace BasicFramework.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<UserInfo> list = new List<UserInfo>()
            {
                new UserInfo { UserName="saber",Age=18},new UserInfo { UserName="archar",Age=20},new UserInfo { UserName="张三",Age=20}
            };
            //Func<UserInfo, dynamic> key = item => new {item.Age };
            //var temp= list.GroupBy(key).ToList();
            Tuple<List<UserInfo>, int, int> tuple = new Tuple<List<UserInfo>, int, int>(list,list.Count(),1);
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        public class UserInfo
        {
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

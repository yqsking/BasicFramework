using BasicFramework.Common.Expand;
using System;
using System.Collections.Generic;

namespace BasicFramework.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<UserInfo> list = new List<UserInfo>
            {
                new UserInfo{ UserName="admin",Age=22},
                new UserInfo { UserName="saber",Age=20}
            };
            var table= list.ToDataTable();
            System.Console.WriteLine("hello");
        }

        public class UserInfo
        {
           
            public string UserName { get; set; }

            public int Age { get; set; }
        }
    }
}

using BasicFramework.Common.Expands;
using BasicFramework.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace BasicFramework.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string path= Directory.GetCurrentDirectory() + "\\File\\UserInfo.xlsx";
            string fileExt = Path.GetExtension(path).ToLower();
            if ( File.Exists(path))
            {
                Stream stream = File.OpenRead(path);
                var table= ExcelHelper.ImportExcel(stream,fileExt,0);
            }
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

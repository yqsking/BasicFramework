using System;

namespace BasicFramework.Common.Attributes
{
    /// <summary>
    /// 登录授权
    /// </summary>
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method)]
    public  class AuthorizeAttribute:Attribute
    {
    }
}

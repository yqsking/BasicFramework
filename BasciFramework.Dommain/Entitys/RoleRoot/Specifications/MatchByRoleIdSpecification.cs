using BasicFramework.Dommain.Common.Interfaces;
using System;
using System.Linq.Expressions;
using System.Linq;
namespace BasicFramework.Dommain.Entitys.RoleRoot.Specifications
{
    public  class MatchByRoleIdSpecification:ISpecification<RoleRootEntity>
    {
        private readonly string[] _roleIds;
        public MatchByRoleIdSpecification(params string[] roleIds)
        {
            _roleIds = roleIds;
        }

        public Expression<Func<RoleRootEntity, bool>> GetExpression()
        {
            return item => _roleIds.Contains(item.RoleId);
        }
    }
}

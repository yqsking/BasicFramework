using BasicFramework.Dommain.Common.Models;
using System;
using System.Linq.Expressions;

namespace BasicFramework.Dommain.Common.Interfaces
{
    public interface ISpecification<TEntity> where TEntity:BaseEntity
    {
        //ISpecification<TEntity> And(ISpecification<TEntity> specification);

        //ISpecification<TEntity> AndIf(bool condition,ISpecification<TEntity> specification);

        //ISpecification<TEntity> Or(ISpecification<TEntity> specification);

        //ISpecification<TEntity> OrIf(ISpecification<TEntity> specification);

        Expression<Func<TEntity, bool>> GetExpression();
    }
}

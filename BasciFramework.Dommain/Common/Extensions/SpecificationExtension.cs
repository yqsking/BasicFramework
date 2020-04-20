using BasicFramework.Dommain.Common.Interfaces;
using BasicFramework.Dommain.Common.Models;

namespace BasicFramework.Dommain.Common.Extensions
{
    public static class SpecificationExtension
    {

        public static ISpecification<TEntity> And<TEntity>(this ISpecification<TEntity> left, ISpecification<TEntity> right) where TEntity : BaseEntity
        {
            return default;
        }

        /// <summary>
        /// 当前置条件成立时，左查询规范与右查询规范用And关系链接;前置条件不成立时，返回左查询规范
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="left">左查询规范</param>
        /// <param name="condition">前置条件</param>
        /// <param name="right">右查询规范</param>
        /// <returns></returns>
        public static ISpecification<TEntity> AndIf<TEntity>(this ISpecification<TEntity> left, bool condition, ISpecification<TEntity> right) where TEntity:BaseEntity
        {
            return condition ? left.And(right) : left;
        }


        public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> left, ISpecification<TEntity> right) where TEntity : BaseEntity
        {
            return default;
        }

        /// <summary>
        /// 当前置条件成立时，左查询规范与右查询规范用Or关系链接;前置条件不成立时，返回左查询规范
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="left">左查询规范</param>
        /// <param name="condition">前置条件</param>
        /// <param name="right">右查询规范</param>
        /// <returns></returns>
        public static ISpecification<TEntity> OrIf<TEntity>(this ISpecification<TEntity> left, bool condition, ISpecification<TEntity> right) where TEntity : BaseEntity
        {
            return condition ? left.Or(right) : left;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using EfSearchModel.Model;

namespace DAL
{
    /// <summary>
    /// 接口基类
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IBaseService<T> where T:class,new()
    {
        /// <summary>
        /// 数据实体列表
        /// </summary>
        IQueryable<T> Entities { get; }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>添加后的数据实体</returns>
        T Add(T entity, bool isSave = true);

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///更新实体 
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns></returns>
        bool Update(T entity, bool isSave = true);



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        bool Delete(T entity, bool isSave = true);


        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>影响的记录数目</returns>
        int Save();

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exist(Expression<Func<T, bool>> anyLambda);

        /// <summary>
        /// 查找数据【优先使用】
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns>实体</returns>
        T GetModel(int Id);

        /// <summary>
        /// 查询数据 
        /// </summary>
        /// <param name="whereLambda">条件表达式</param>
        /// <returns>实体</returns>
        T GetModel(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLamdba">查询表达式</param>
        /// <returns>实体集合</returns>
       IQueryable<T>  GetList(Expression<Func<T, bool>> whereLamdba);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序字段</param>
        /// <param name="isAsc">是否正序</param>
        /// <returns>实体集合</returns>
        IQueryable<T> GetList(Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc);

        /// <summary>
        /// 查询Top(n)实体
        /// </summary>
        /// <param name="top">n数值</param>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序字段</param>
        /// <param name="isAsc">是否正序</param>
        /// <returns>实体集合</returns>
        IQueryable<T> GetList(int top, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc);

        /// <summary>
        /// 分页查询数据(查询表达式基于linq表达式)
        /// </summary>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序字段</param>
        /// <param name="isAsc">是否正序</param>
        /// <param name="totalRecord">总记录数</param>
        /// <returns>实体集合</returns>
        IQueryable<T> GetList(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc, out int totalRecord);

        /// <summary>
        /// 分页查询数据(查询表达式基于EfSearchModel表达式)
        /// </summary>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序字段</param>
        /// <param name="isAsc">是否正序</param>
        /// <param name="totalRecord">总记录数</param>
        /// <returns>实体集合</returns>
      //  IQueryable<T> FindPageList(int pageSize, int pageIndex, QueryModel queryModel, string orderName, bool isAsc, out int totalRecord);

    }
}

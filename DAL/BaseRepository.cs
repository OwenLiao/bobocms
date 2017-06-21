
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using System.Linq.Dynamic;

namespace DAL
{

    /// <summary>
    /// 仓储基类
    /// </summary>
    public  class BaseRepository<T> : IBaseService<T> where T : class,new()
  //  public  class BaseRepository<T>  where T : class
    {
        protected MyDbContext nContext;
        public BaseRepository(MyDbContext _context)
        {
            nContext = _context;
        }

        public IQueryable<T> Entities
        {
            get { return nContext.Set<T>(); }
        }

        public T Add(T entity, bool isSave = true)
        {
            nContext.Set<T>().Add(entity);
            if (isSave) nContext.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return nContext.Set<T>().Count(predicate);
        }

        public bool Update(T entity, bool isSave = true)
        {
            //nContext.Set<T>().Attach(entity);
            //nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            //return isSave ? nContext.SaveChanges() > 0 : true;
            return false;
        }

        public bool Delete(T entity, bool isSave = true)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return isSave ? nContext.SaveChanges() > 0 : true;
        }


        public bool Delete(int Id, bool isSave = true)
        {
          return Delete(  GetModel(Id));
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return nContext.Set<T>().Any(anyLambda);
        }

        public int Save()
        {
            return nContext.SaveChanges();
        }

        public T GetModel(int Id)
        {
            return nContext.Set<T>().Find(Id);
        }

        public T GetModel(Expression<Func<T, bool>> whereLambda)
        {
            T _entity = nContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }

        public  IQueryable<T> GetList(Expression<Func<T, bool>> whereLamdba)
        {
            var _list = nContext.Set<T>().Where<T>(whereLamdba);
            return _list;
        }

        //public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba,)
        //{
        //    var _list = nContext.Set<T>().Where<T>(whereLamdba);
        //    return _list;
        //}

        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var _list = nContext.Set<T>().Where<T>(whereLamdba);
            _list = OrderBy(_list, orderName, isAsc);
            return _list;
        }

        public IQueryable<T> GetList(int top, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var _list = nContext.Set<T>().Where<T>(whereLamdba);
            _list = OrderBy(_list, orderName, isAsc).Take<T>(top);
            return _list;
        }

        public IQueryable<T> GetList(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc, out int totalRecord)
        {
            var _list = nContext.Set<T>().Where<T>(whereLamdba);
            totalRecord = _list.Count();
            _list = OrderBy(_list, orderName, isAsc).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            return _list;
        }

        //public IQueryable<T> FindPageList(int pageSize, int pageIndex, EfSearchModel.Model.QueryModel queryModel, string orderName, bool isAsc, out int totalRecord)
        //{
        //    var _list = nContext.Set<T>().Where<T>(queryModel);
        //    totalRecord = _list.Count();
        //    _list = OrderBy(_list, orderName, isAsc).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
        //    return _list;
        //}

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="source">原IQueryable</param>
        /// <param name="propertyName">排序属性名</param>
        /// <param name="isAsc">是否正序</param>
        /// <returns>排序后的IQueryable<T></returns>
        private IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc)
        {

            if (source == null)
            {
                throw new ArgumentNullException("source", "不能为空");
            }

            if (string.IsNullOrEmpty(propertyName)) return source;
            var _parameter = Expression.Parameter(source.ElementType);
            var _property = Expression.Property(_parameter, propertyName);
            if (_property == null) throw new ArgumentNullException("propertyName", "属性不存在");
            var _lambda = Expression.Lambda(_property, _parameter);
            var _methodName = isAsc ? "OrderBy" : "OrderByDescending";
            var _resultExpression = Expression.Call(typeof(Queryable), _methodName, new Type[] { source.ElementType, _property.Type }, source.Expression, Expression.Quote(_lambda));
            return source.Provider.CreateQuery<T>(_resultExpression);

        }



        //#region MyRegion

        //public List<TResult> Query<TEntity, TOrderBy, TResult>(IQueryable<TEntity> query,
        //                                                             Expression<Func<TEntity, bool>> where,
        //                                                             Expression<Func<TEntity, TOrderBy>> orderby,
        //                                                             Expression<Func<TEntity, int, TResult>> selector,
        //                                                             bool isAsc)
        //{
        //    if (selector == null)
        //    {
        //        throw new ArgumentNullException("selector");
        //    }

        //    var queryable = query;
        //    if (where != null)
        //    {
        //        queryable = queryable.Where(where);
        //    }
        //    if (orderby != null)
        //    {
        //        queryable = isAsc ? queryable.OrderBy(orderby) : queryable.OrderByDescending(orderby);
        //    }

        //    return queryable.Select(selector).ToList();
        //}

        //public List<object> Query<TEntity, TOrderBy>(IQueryable<TEntity> query,
        //                                                              Expression<Func<TEntity, bool>> where,
        //                                                              Expression<Func<TEntity, TOrderBy>> orderby,
        //                                                              Func<IQueryable<TEntity>, List<object>> selector,
        //                                                              bool isAsc)
        //{
        //    if (selector == null)
        //    {
        //        throw new ArgumentNullException("selector");
        //    }

        //    var queryable = query;
        //    if (where != null)
        //    {
        //        queryable = queryable.Where(where);
        //    }
        //    if (orderby != null)
        //    {
        //        queryable = isAsc ? queryable.OrderBy(orderby) : queryable.OrderByDescending(orderby);
        //    }

        //    return selector(queryable);
        //}

        //public PageInfo<object> Query<TEntity, TOrderBy>(IQueryable<TEntity> query, int index, int pageSize,
        //                                                        Expression<Func<TEntity, bool>> where,
        //                                                        Expression<Func<TEntity, TOrderBy>> orderby,
        //                                                        Func<IQueryable<TEntity>, List<object>> selector,
        //                                                        bool isAsc)
        //{
        //    return Query(query, index, pageSize, new List<Expression<Func<TEntity, bool>>> {where}, orderby, selector,
        //                 isAsc);
        //}
        //public PageInfo<object> Query<TEntity, TOrderBy>(IQueryable<TEntity> query, int index, int pageSize,
        //                                                 List<Expression<Func<TEntity, bool>>> wheres,
        //                                                 Expression<Func<TEntity, TOrderBy>> orderby,
        //                                                 Func<IQueryable<TEntity>, List<object>> selector, bool isAsc)
        //{
        //    //if (selector == null)
        //    //{
        //    //    throw new ArgumentNullException("selector");
        //    //}

        //    //PageInfo.CheckPageIndexAndSize(ref index,ref pageSize);
        //    //IQueryable<TEntity> queryable = query;
        //    //if (wheres != null)
        //    //{
        //    //    wheres.ForEach(p=>queryable = queryable.Where(p));
        //    //}

        //    //int count = query.Count();
        //    //PageInfo.CheckPageIndexAndSize(ref index,pageSize,count);
        //    //if (count > 0)
        //    //{
        //    //    if (orderby != null)
        //    //    {
        //    //        queryable = isAsc ? queryable.OrderBy(orderby) : queryable.OrderByDescending(orderby);

        //    //    }

        //    //    return new PageInfo<object>(index,pageSize,count,selector(queryable));
        //    //}

        //    //return new PageInfo<object>(index,pageSize,count,new List<object>());

        //    return Query<TEntity, TOrderBy, object>(query, index, pageSize, wheres, orderby, selector, isAsc);
        //}

        //public PageInfo<TResult> Query<TEntity, TOrderBy, TResult>(IQueryable<TEntity> query, int index, int pageSize,
        //                                                 List<Expression<Func<TEntity, bool>>> wheres,
        //                                                 Expression<Func<TEntity, TOrderBy>> orderby,
        //                                                 Func<IQueryable<TEntity>, List<TResult>> selector, bool isAsc)
        //{
        //    if (selector == null)
        //    {
        //        throw new ArgumentNullException("selector");
        //    }

        //    PageInfo.CheckPageIndexAndSize(ref index, ref pageSize);
        //    IQueryable<TEntity> queryable = query;
        //    if (wheres != null)
        //    {
        //        wheres.ForEach(p => queryable = queryable.Where(p));
        //    }

        //    int count = query.Count();
        //    PageInfo.CheckPageIndexAndSize(ref index, pageSize, count);
        //    if (count > 0)
        //    {
        //        if (orderby != null)
        //        {
        //            queryable = isAsc ? queryable.OrderBy(orderby) : queryable.OrderByDescending(orderby);

        //        }

        //        return new PageInfo<TResult>(index, pageSize, count, selector(queryable));
        //    }

        //    return new PageInfo<TResult>(index, pageSize, count, new List<TResult>());
        //}

        //public PageInfo<TResult> Query<TEntity, TOrderBy, TResult>(IQueryable<TEntity> query, int index, int pageSize,
        //                                                        Expression<Func<TEntity, bool>> where,
        //                                                        Expression<Func<TEntity, TOrderBy>> orderby,
        //                                                        Func<IQueryable<TEntity>, List<TResult>> selector,
        //                                                        bool isAsc)
        //{
        //    return Query(query, index, pageSize, new List<Expression<Func<TEntity, bool>>> { where }, orderby, selector,
        //                 isAsc);
        //}

        //#endregion

        //#region pageInfo
        //public class PageInfo
        //{
        //    public void CheckPageIndexAndSize(ref int index, ref int size)
        //    {
        //        if (index < 1)
        //        {
        //            index = 1;
        //        }

        //        if (size < 1)
        //        {
        //            size = 20;
        //        }
        //    }

        //    public void CheckPageIndexAndSize(ref int index, int size, int count)
        //    {
        //        if (count >= index * size)
        //        {
        //            return;
        //        }

        //        index = count / size;
        //        if (count % size > 0)
        //        {
        //            index++;
        //        }

        //        if (index == 0)
        //        {
        //            index = 1;
        //        }
        //    }

        //}

        //public class PageInfo<T> : PageInfo
        //{
        //    internal PageInfo()
        //    {
        //        DataList = new List<T>();
        //    }
        //    public PageInfo(int index, int pageSize, int count, List<T> dataList)
        //    {
        //        Index = index;
        //        PageSie = pageSize;
        //        Count = count;
        //        DataList = dataList;
        //    }

        //    public int Index { get; private set; }
        //    public int PageSie { get; private set; }
        //    public int Count { get; private set; }
        //    public List<T> DataList { get; private set; }

        //    public PageInfo<T> Empty
        //    {
        //        get { return new PageInfo<T>(); }
        //    }
        //}
        //#endregion


    }
}

//using EfSearchModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using DAL;
using System.Collections;


namespace BLL
{
    // public abstract class BaseService<T>:IBaseService<T> where T : class
    public abstract class BaseService<T> where T : class
    {
        

        protected BaseRepository<T> baseRepository;
   
        public BaseService(BaseRepository<T> _baseRepository)
        {
            baseRepository = _baseRepository;
        }





        public virtual T Add(T entity, bool isSave = true)
        {
            return baseRepository.Add(entity, isSave);
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return baseRepository.Count(predicate);
        }

        public virtual bool Update(T entity, bool isSave = true)
        {
            return baseRepository.Update(entity, isSave);
        }

        public virtual bool Delete(T entity, bool isSave = true)
        {
            return baseRepository.Delete(entity, isSave);
        }

        public virtual bool Delete(int Id, bool isSave = true)
        {
            return Delete(GetModel(Id));
        }

        public int Save()
        {
            return baseRepository.Save();
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return baseRepository.Exist(anyLambda);
        }

        public T GetModel(int Id)
        {
            return baseRepository.Find(Id);
        }



        public T GetModel(Expression<Func<T, bool>> whereLambda)
        {
            return baseRepository.Find(whereLambda);
        }


        public Task<IQueryable<T>> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return baseRepository.FindList(whereLambda);
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            return baseRepository.FindList(whereLamdba, orderName, isAsc);
        }

        public IQueryable<T> GetList(int top, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            return baseRepository.FindList(top, whereLamdba, orderName, isAsc);
        }

        public IQueryable<T> GetList(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc, out int totalRecord)
        {
            return baseRepository.FindPageList(pageSize, pageIndex, whereLamdba, orderName, isAsc, out totalRecord);
        }

        //public IQueryable<T> GetList(int pageSize, int pageIndex, QueryModel queryModel, string orderName, bool isAsc, out int totalRecord)
        //{
        //    return baseRepository.FindPageList(pageSize, pageIndex, queryModel, orderName, isAsc, out totalRecord);
        //}

        #region 从缓存中取列表
        delegate List<T> GetListCacheCommon(IEnumerable query);


        // MyCache.EnyimMemcachedContext memCached = new MyCache.EnyimMemcachedContext();

        //public List<T> GetListCache(Expression<Func<T, bool>> whereLambda, string key, string field = null, int minute = 30)
        //{
        //    List<T> listCache = null;
        //    var cache = memCached.Get(key);
        //    if (cache != null)
        //    {
        //        listCache = Common.JsonHelper.JsonToList<T>(cache.ToString());
        //    }
        //    if (listCache == null)
        //    {
        //        IEnumerable query;
        //        List<T> list;
        //        string json = string.Empty;
        //        if (!string.IsNullOrEmpty(field))
        //        {
        //            query = baseRepository.FindList(whereLambda).Select("new(" + field + ")");
        //            var list1 = query.Cast<dynamic>().ToList();
        //            json = Common.JsonHelper.ObjectToJSON(list1);
        //            list = Common.JsonHelper.JsonToList<T>(json);
        //        }
        //        else
        //        {
        //            query = baseRepository.FindList(whereLambda);
        //            list = query.Cast<T>().ToList();
        //            json = Common.JsonHelper.ObjectToJSON(list);
        //        }
        //        //   memCached.Set<List<T>>(key, list, minute);
        //        try
        //        {
        //            bool b = memCached.Store(StoreMode.Set, key, json, DateTime.Now.AddMinutes(minute));
        //        }
        //        catch (Exception ex)
        //        {
        //            Common.Utils.WriteToTxtFile("添加缓存失败.txt", key + "    " + ex.Message);
        //        }

        //        //   Common.Utils.WriteToTxtFile("GetListCache.txt", key + "    " + b.ToString());

        //        return list;
        //    }
        //    return listCache;
        //}

        //public List<T> GetListCache(Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc, string key, string field = null, int minute = 30)
        //{
        //    //List<T> listCache = memCached.Get<List<T>>(key);
        //    List<T> listCache = null;
        //    var cache = memCached.Get(key);
        //    if (cache != null)
        //    {
        //        listCache = Common.JsonHelper.JsonToList<T>(cache.ToString());
        //    }
        //    if (listCache == null)
        //    {
        //        IEnumerable query;
        //        List<T> list;
        //        string json = string.Empty;
        //        if (!string.IsNullOrEmpty(field))
        //        {
        //            query = baseRepository.FindList(whereLamdba, orderName, isAsc).Select("new(" + field + ")");
        //            var list1 = query.Cast<dynamic>().ToList();
        //            json = Common.JsonHelper.ObjectToJSON(list1);
        //            list = Common.JsonHelper.JsonToList<T>(json);
        //        }
        //        else
        //        {
        //            query = baseRepository.FindList(whereLamdba, orderName, isAsc);
        //            list = query.Cast<T>().ToList();
        //            json = Common.JsonHelper.ObjectToJSON(list);
        //        }
        //        //memCached.Set<List<T>>(key, list, minute);

        //        try
        //        {
        //            bool b = memCached.Store(StoreMode.Set, key, json, DateTime.Now.AddMinutes(minute));
        //        }
        //        catch (Exception ex)
        //        {
        //            Common.Utils.WriteToTxtFile("添加缓存失败.txt", key + "    " + ex.Message);
        //        }

        //        //  Common.Utils.WriteToTxtFile("GetListCache.txt", key + "    " + b.ToString());
        //        return list;
        //    }
        //    return listCache;
        //}

        //public List<T> GetListCache(int top, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc, string key, string field = null, int minute = 30)
        //{
        //    //   List<T> listCache = memCached.Get<List<T>>(key);
        //    List<T> listCache = null;
        //    var cache = memCached.Get(key);
        //    if (cache != null)
        //    {
        //        listCache = Common.JsonHelper.JsonToList<T>(cache.ToString());
        //    }

        //    if (listCache == null)
        //    {
        //        IEnumerable query = null;
        //        List<T> list = null;
        //        string json = string.Empty;
        //        if (!string.IsNullOrEmpty(field))
        //        {


        //            try
        //            {
        //                query = baseRepository.FindList(top, whereLamdba, orderName, isAsc).Select("new(" + field + ")");

        //            }
        //            catch (Exception ex)
        //            {
        //                string ss = top + "  " + orderName + "   " + isAsc + "   " + field;

        //                Common.Utils.WriteToTxtFile("添加缓存失败7" + DateTime.Now.ToString("mmssfff") + ".txt", key + "    " + ex.Message + "   " + DateTime.Now.ToString() + Environment.NewLine + ss + Environment.NewLine + ex.StackTrace);
        //            }


        //            List<dynamic> list1 = null;
        //            try
        //            {
        //                list1 = query.Cast<dynamic>().ToList();

        //            }
        //            catch (Exception ex)
        //            {

        //                Common.Utils.WriteToTxtFile("添加缓存失败5" + DateTime.Now.ToString("mmssfff") + ".txt", key + "    " + ex.Message + "   " + DateTime.Now.ToString());
        //            }

        //            json = Common.JsonHelper.ObjectToJSON(list1);
        //            list = Common.JsonHelper.JsonToList<T>(json);

        //        }
        //        else
        //        {
        //            query = baseRepository.FindList(top, whereLamdba, orderName, isAsc);
        //            list = query.Cast<T>().ToList();
        //            json = Common.JsonHelper.ObjectToJSON(list);

        //        }
        //        //   memCached.Set<List<T>>(key, list, minute);

        //        bool b = memCached.Store(StoreMode.Set, key, json, DateTime.Now.AddMinutes(minute));
        //        //  Common.Utils.WriteToTxtFile("GetListCache.txt", key + "    " + b.ToString());
        //        return list;
        //    }
        //    return listCache;
        //}

        //public List<T> GetListCache(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc, out int totalRecord, string key, string field = null, int minute = 30)
        //{

        //    //List<T> listCache = memCached.Get<List<T>>(key);

        //    List<T> listCache = null;
        //    var cache = memCached.Get(key);
        //    if (cache != null)
        //    {
        //        listCache = Common.JsonHelper.JsonToList<T>(cache.ToString());
        //    }

        //    object countCache = memCached.Get<object>(key + "_totalRecord");

        //    if (listCache == null || countCache == null)
        //    {
        //        IEnumerable query;
        //        List<T> list;
        //        string json = string.Empty;
        //        if (!string.IsNullOrEmpty(field))
        //        {
        //            query = baseRepository.FindPageList(pageSize, pageIndex, whereLamdba, orderName, isAsc, out totalRecord).Select("new(" + field + ")");
        //            var list1 = query.Cast<dynamic>().ToList();
        //            json = Common.JsonHelper.ObjectToJSON(list1);
        //            list = Common.JsonHelper.JsonToList<T>(json);
        //        }
        //        else
        //        {
        //            query = baseRepository.FindPageList(pageSize, pageIndex, whereLamdba, orderName, isAsc, out totalRecord);
        //            list = query.Cast<T>().ToList();
        //            json = Common.JsonHelper.ObjectToJSON(list);
        //        }
        //        //bool b = memCached.Set<List<T>>(key, list, minute);
        //        // bool b1 = memCached.Set<object>(key + "_totalRecord", totalRecord, minute);
        //        try
        //        {
        //            bool b = memCached.Store(StoreMode.Set, key, json, DateTime.Now.AddMinutes(minute));

        //            bool b1 = memCached.Store(StoreMode.Set, key + "_totalRecord", totalRecord, DateTime.Now.AddMinutes(minute));
        //        }
        //        catch (Exception ex)
        //        {
        //            Common.Utils.WriteToTxtFile("添加缓存失败.txt", key + "    " + ex.Message);
        //        }

        //        //  Common.Utils.WriteToTxtFile("GetListCache.txt", key + "    " + b.ToString() + "    " + b1.ToString());
        //        return list;
        //    }
        //    else
        //    {
        //        //  Common.Utils.WriteToTxtFile("GetListCacheSuccess.txt", key);
        //    }
        //    totalRecord = Convert.ToInt32(countCache);
        //    return listCache;
        //}

        //public List<T> GetListCache(int pageSize, int pageIndex, QueryModel queryModel, string orderName, bool isAsc, out int totalRecord, string key, string field = null, int minute = 30)
        //{
        //    List<T> listCache = null;
        //    var cache = memCached.Get(key);
        //    if (cache != null)
        //    {
        //        listCache = Common.JsonHelper.JsonToList<T>(cache.ToString());
        //    }

        //    object countCache = memCached.Get<object>(key + "_totalRecord");
        //    if (listCache == null || countCache == null)
        //    {
        //        IEnumerable query;
        //        List<T> list;
        //        string json = string.Empty;
        //        if (!string.IsNullOrEmpty(field))
        //        {
        //            query = baseRepository.FindPageList(pageSize, pageIndex, queryModel, orderName, isAsc, out totalRecord).Select("new(" + field + ")");
        //            var list1 = query.Cast<dynamic>().ToList();
        //            json = Common.JsonHelper.ObjectToJSON(list1);
        //            list = Common.JsonHelper.JsonToList<T>(json);
        //        }
        //        else
        //        {
        //            query = baseRepository.FindPageList(pageSize, pageIndex, queryModel, orderName, isAsc, out totalRecord);
        //            list = query.Cast<T>().ToList();
        //            json = Common.JsonHelper.ObjectToJSON(list);
        //        }
        //        //     memCached.Set<List<T>>(key, list, minute);
        //        //   memCached.Set<object>(key + "_totalRecord", totalRecord, minute);


        //        try
        //        {
        //            bool b = memCached.Store(StoreMode.Set, key, json, DateTime.Now.AddMinutes(minute));
        //            bool b1 = memCached.Store(StoreMode.Set, key + "_totalRecord", totalRecord, DateTime.Now.AddMinutes(minute)); ;
        //        }
        //        catch (Exception ex)
        //        {
        //            Common.Utils.WriteToTxtFile("添加缓存失败.txt", key + "    " + ex.Message);
        //        }
        //        //  Common.Utils.WriteToTxtFile("GetListCache.txt", key + "    " + b.ToString() + "    " + b1.ToString());
        //        return list;
        //    }
        //    totalRecord = Convert.ToInt32(countCache);
        //    return listCache;
        //}
        #endregion
    }
}

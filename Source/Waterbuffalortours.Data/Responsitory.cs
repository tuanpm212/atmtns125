using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Waterbuffalortours.Data
{
    public class Responsitory<T> : IRespository<T> where T : class
    {

        #region Get Data

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    List<T> list;
                    IQueryable<T> dbQuery = db.Set<T>();

                    //Apply eager loading
                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);

                    list = dbQuery
                        .AsNoTracking()
                        .ToList<T>();
                    this.TotalRows = list.Count();
                    return list;
                }
            }
            catch
            {
                throw;
            }
        }

        public IList<T> GetAll(int startRow, int maxRow, params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    List<T> list;
                    IQueryable<T> dbQuery = db.Set<T>();

                    //Apply eager loading
                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);

                    list = dbQuery
                        .AsNoTracking()
                        .ToList<T>();
                    this.TotalRows = list.Count();
                    return list.Skip(startRow).Take(maxRow).ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    List<T> list;
                    IQueryable<T> dbQuery = db.Set<T>();

                    //Apply eager loading
                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);

                    list = dbQuery
                        .AsNoTracking()
                        .Where(where)
                        .ToList<T>();
                    this.TotalRows = list.Count();
                    return list;
                }
            }
            catch
            {
                throw;
            }
        }

        public IList<T> GetList(int startRow, int maxRow, Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    List<T> list;
                    IQueryable<T> dbQuery = db.Set<T>();

                    //Apply eager loading
                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);

                    list = dbQuery
                        .AsNoTracking()
                        .Where(where)
                        .ToList<T>();
                    this.TotalRows = list.Count();
                    return list.Skip(startRow).Take(maxRow).ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    T item = null;
                    IQueryable<T> dbQuery = db.Set<T>();

                    //Apply eager loading
                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);

                    item = dbQuery
                        .AsNoTracking() //Don't track any changes for the selected item
                        .FirstOrDefault(where); //Apply where clause
                    this.TotalRows = 1;
                    return item;
                }
            }
            catch
            {
                throw;
            }
        }

        public T GetByID(object ID)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    return db.Set<T>().Find(ID);
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Insert, Update, Delete

        /// <summary>
        /// Add new item
        /// </summary>
        /// <param name="item">Object</param>
        /// <returns>True/False</returns>
        public bool Add(T item)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Add news multi items
        /// </summary>
        /// <param name="items">list items</param>
        /// <returns>True/False</returns>
        public bool Add(List<T> items)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    foreach (T item in items)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Added;
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>True/False</returns>
        public bool Update(T item)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    DbSet dbSet = db.Set<T>();
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update list items
        /// </summary>
        /// <param name="items">List items</param>
        /// <returns>True/False</returns>
        public bool Update(List<T> items)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    foreach (T item in items)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete item by ID
        /// </summary>
        /// <param name="ID">Item ID</param>
        /// <returns>True/False</returns>
        public bool Delete(object ID)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    DbSet<T> dbSet;
                    dbSet = db.Set<T>();
                    T obj = db.Set<T>().Find(ID);
                    if (db.Entry(obj).State == EntityState.Detached)
                    {
                        dbSet.Attach(obj);
                    }

                    dbSet.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete multi items
        /// </summary>
        /// <param name="items">List items</param>
        /// <returns>True/False</returns>
        public bool Delete(List<T> items)
        {
            try
            {
                using (var db = new DBEntities())
                {
                    DbSet<T> dbSet;
                    dbSet = db.Set<T>();
                    dbSet.RemoveRange(items);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }


        #endregion

        #region Get & Set
        public int TotalRows { get; set; }

        #endregion
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Waterbuffalortours.Data
{
    /// <summary>
    /// Repository class: Contain basic functions
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    public interface IRespository<T> where T : class
    {
        #region Get Data

            IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

            IList<T> GetAll(int startRow, int maxRows, params Expression<Func<T, object>>[] navigationProperties);

            IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

            IList<T> GetList(int startRow, int maxRows, Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

            T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

            T GetByID(object ID);

        #endregion

        #region Insert, Update, Delete

            bool Add(T item);

            bool Add(List<T> items);

            bool Update(T item);

            bool Update(List<T> items);

            bool Delete(object ID);

            bool Delete(List<T> items);

        #endregion

        #region Get & set
            int TotalRows { get; set; }
        #endregion
    }
}


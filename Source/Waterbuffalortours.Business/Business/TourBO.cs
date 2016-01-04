using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Waterbuffalortours.Data;

namespace Waterbuffalortours.Business
{
    public class TourBO: Responsitory<Tour>, ITours
    {
        public List<Tour> GetHomeTour()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    var select = from c in db.Tours
                                 where c.IsActive && c.IsHost
                                 orderby c.TourName
                                 select c;

                    return select.Skip(0).Take(2).ToList();
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}

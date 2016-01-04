using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterbuffalortours.Data;

namespace Waterbuffalortours.Business
{
    public interface IHome: IRespository<vw_SlideDetail>
    {
        Model.HomeDOT GetHomeData();
    }
}

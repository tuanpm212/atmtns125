using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterbuffalortours.Data;

namespace Waterbuffalortours.Business
{
    public class HomeBO: Responsitory<vw_SlideDetail>, IHome
    {
        public Model.HomeDOT GetHomeData()
        {
            try
            {
                var data = new Model.HomeDOT();
                var slides = this.GetList(m => m.SlideType == "HOME").ToList();
                data.Sliders = new List<vw_SlideDetail>();
                data.Sliders = slides;

                var textDataBO = new TextDataBO();

                data.Introduction = new TextData();
                data.Introduction = textDataBO.GetList(m => m.TextID == "WELCOME_HOME").First();

                return data;
            }
            catch
            {
                return null;
            }
        }
    }
}

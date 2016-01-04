using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterbuffalortours.Data;

namespace Waterbuffalortours.Business.Model
{
    public class HomeDOT
    {
        public List<vw_SlideDetail> Sliders { get; set; }
        public TextData Introduction { get; set; }
        public List<Tour> Tours { get; set; }
    }
}

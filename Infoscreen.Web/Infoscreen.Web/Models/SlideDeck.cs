using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infoscreen.Web.Model
{
    public class SlideDeck
    {
        public IList<Slide> Slides { get; set; }

        public int GetNextId()
        {
            return Slides.Max(s => s.Id) + 1;
        }
    }
}

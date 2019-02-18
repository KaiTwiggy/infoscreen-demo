using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infoscreen.Web.Model
{
    public class Slide
    {
        public string CardType { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }


        public string Name { get; set; }

        public JObject data { get; set; }
    }
}

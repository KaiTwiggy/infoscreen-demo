using Infoscreen.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infoscreen.Web.Services
{
    public interface ISlideService
    {
        Task<SlideDeck> GetSlides();

        Task<string> GetSlidesRaw();

        void UpdateSlides(SlideDeck slideDeck);

    }
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Infoscreen.Web.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Infoscreen.Web.Services;

namespace Infoscreen.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Slide")]
    public class SlideController : Controller
    {
        private ISlideService _slideService { get; set; }

        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
        }

        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            var slideDeck = await _slideService.GetSlides();
            return new ObjectResult(slideDeck.Slides.Where(s => !s.IsDeleted));
        }
            
        [HttpGet]
        [Route("{id}")]
        public async Task<ObjectResult> Get(int id)
        {
            var slideDeck = await _slideService.GetSlides();
            var slide = slideDeck.Slides.FirstOrDefault(s => !s.IsDeleted && s.Id == id);

            return new ObjectResult(slide);
        }

        [HttpGet]
        [Route("toggleActivation/{id}")]
        public async Task<StatusCodeResult> ToggleActivation(int id)
        {
            var slideDeck = await _slideService.GetSlides();

            var slide = slideDeck.Slides.FirstOrDefault(s => s.Id == id);
            slide.IsActive = !slide.IsActive;

            var newData = JsonConvert.SerializeObject(slideDeck);
            await System.IO.File.WriteAllTextAsync(@"./data.json", newData);

            return new OkResult();
        }

        [HttpPost]
        public async Task<StatusCodeResult> Post([FromBody]JToken token)
        {
            var slideDeck = await _slideService.GetSlides();

            var newSlide = JsonConvert.DeserializeObject<Slide>(token.ToString());

            newSlide.Id = slideDeck.GetNextId();
            slideDeck.Slides.Add(newSlide);

            _slideService.UpdateSlides(slideDeck);

            return new OkResult();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<StatusCodeResult> Delete(int id)
        {
            var slideDeck = await _slideService.GetSlides();

            var slide = slideDeck.Slides.FirstOrDefault(s => s.Id == id);
            slide.IsDeleted = true;

            _slideService.UpdateSlides(slideDeck);

            return new OkResult();
        }
    }
}
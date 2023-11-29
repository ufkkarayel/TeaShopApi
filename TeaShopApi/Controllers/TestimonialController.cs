using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.TestimonialDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values =_testimonialService.TGetListAll();
            return Ok(values);

        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                TestimonialComment = createTestimonialDto.TestimonialComment,
                TestimonialImageUrl = createTestimonialDto.TestimonialImageUrl,
                TestimonialName = createTestimonialDto.TestimonialName
            };
            _testimonialService.TInsert(testimonial);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id) 
        {
            var values=_testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return Ok(values);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.MessageDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public ActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);

        }
        [HttpPost]
        public ActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                SenderName = createMessageDto.SenderName,
                MessageDetail = createMessageDto.MessageDetail,
                MessageEmail = createMessageDto.MessageEmail,
                MessageSendDate = createMessageDto.MessageSendDate,
                MessageSubject = createMessageDto.MessageSubject
            };
            _messageService.TInsert(message);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var values=_messageService.TGetByID(id);
            _messageService.TDelete(values);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var values = _messageService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
                MessageID = updateMessageDto.MessageID,
                MessageDetail = updateMessageDto.MessageDetail,
                MessageEmail = updateMessageDto.MessageEmail,
                MessageSendDate = updateMessageDto.MessageSendDate,
                MessageSubject = updateMessageDto.MessageSubject,
                SenderName = updateMessageDto.SenderName
            };
            _messageService.TUpdate(message);
            return Ok("Başarılı bir şekilde güncellendi");           

        }
    }
}

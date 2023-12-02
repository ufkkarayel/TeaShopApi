namespace TeaShopApi.WebUI.Dtos.MessageDtos
{
    public class CreateMessageDto
    {      
        public string SenderName { get; set; }
        public string MessageSubject { get; set; }
        public string MessageEmail { get; set; }
        public string MessageDetail { get; set; }
        public DateTime MessageSendDate { get; set; }
    }
}

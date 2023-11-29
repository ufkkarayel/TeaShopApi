﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DtoLayer.MessageDtos
{
    public class UpdateMessageDto
    {
        public int MessageID { get; set; }
        public string SenderName { get; set; }
        public string MessageSubject { get; set; }
        public string MessageEmail { get; set; }
        public string MessageDetail { get; set; }
        public DateTime MessageSendDate { get; set; }
    }
}

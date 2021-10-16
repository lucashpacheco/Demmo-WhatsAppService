using Demmo_WhatsAppService.Service.Infobip;
using System;
using System.Collections.Generic;

namespace Demmo_WhatsAppService.Model.Infobip
{
    public class TextMessage 
    {
        private readonly IInfobipConfiguration InfobipConfiguration;
        public string from { get; set; }
        public string to { get; set; }
        public Guid messageId { get; set; }
        public TextModel content { get; set; }
        public string callbackData { get; set; }
        public TextMessage()
        {

        }
        public TextMessage(string campaignId ,string to,  string payload)
        {
            InfobipConfiguration = new InfobipConfiguration();

            this.from = InfobipConfiguration.GetFromNumberByCampaign(campaignId);
            this.to = to;
            this.messageId = Guid.NewGuid();
            this.content = new TextModel();
            this.content.text = payload;
            this.callbackData = "Callback data";
        }

    }
    public class Text
    {
        public TextModel text { get; set; }
    }
    public class TextBodyModel
    {
        public TextModel body { get; set; }

    }
    public class TextModel
    {
        public string text { get; set; }

    }
    public class ListTextsMessage
    {
        public List<TextMessage> messages { get; set; }
    }
}

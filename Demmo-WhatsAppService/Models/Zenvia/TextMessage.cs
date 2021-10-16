using Demmo_WhatsAppService.Service.Zenvia;
using System;
using System.Collections.Generic;

namespace Demmo_WhatsAppService.Models.Zenvia
{
    public class TextMessage
    {
        private readonly IZenviaConfiguration ZenviaConfiguration;

        public string from { get; set; }
        public string to { get; set; }
        public List<Text> contents { get; set; }
        public string callbackData { get; set; }
        public TextMessage()
        {

        }
        public TextMessage(string to, string campaignId, string flow, string payload, string language)
        {
            ZenviaConfiguration = new ZenviaConfiguration();
            this.from = ZenviaConfiguration.GetFromSenderIdByCampaign(campaignId);
            this.to = to;
            var text = new Text("text", payload);
            this.contents = new List<Text> {text};
        }

    }
    public class Text
    {

        public string type { get; set; }
        public string text { get; set; }

        public Text()
        {

        }

        public Text(string type, string payload)
        {
            
            this.type = type;
            this.text = payload;


        }
    }
}



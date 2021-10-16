using Demmo_WhatsAppService.Service.Infobip;
using System;
using System.Collections.Generic;

namespace Demmo_WhatsAppService.Model.Infobip
{
    public class TemplateMessage
    {
        private readonly IInfobipConfiguration InfobipConfiguration;

        public string from { get; set; }
        public string to { get; set; }
        public Guid messageId { get; set; }
        public Template content { get; set; }
        public string callbackData { get; set; }
        public TemplateMessage()
        {
            
        }
        public TemplateMessage(string to , string campaignId , string flow , string payload , string language)
        {
            InfobipConfiguration = new InfobipConfiguration();
            this.from = InfobipConfiguration.GetFromNumberByCampaign(campaignId); 
            this.to = to;
            this.messageId = Guid.NewGuid(); 
            this.content = new Template();
            this.content.templateName = InfobipConfiguration.GetTemplateNameByCampaignAndFlow(campaignId , flow);
            this.content.templateData = new TemplateBodyModel();
            this.content.templateData.body = new TemplatePlaceholdersModel();
            this.content.templateData.body.placeholders = new List<string>();
            var payloadList = payload.Split(",");
            foreach (var item in payloadList)
            {
                this.content.templateData.body.placeholders.Add(item);
            }
            this.content.language = language;
            this.callbackData = "Callback data";
        }
    }
    public class Template
    {
        public string templateName { get; set; }
        public TemplateBodyModel templateData { get; set; }
        public string language { get; set; }

    }
    public class TemplateBodyModel
    {
        public TemplatePlaceholdersModel body { get; set; }

    }
    public class TemplatePlaceholdersModel
    {
        public List<string> placeholders { get; set; }

    }
    public class ListTemplatesMessage
    {
        public List<TemplateMessage> messages { get; set; }
    }
}

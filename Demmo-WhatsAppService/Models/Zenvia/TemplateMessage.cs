using Demmo_WhatsAppService.Service.Zenvia;
using System;
using System.Collections.Generic;

namespace Demmo_WhatsAppService.Models.Zenvia
{
    public class TemplateMessage
    {
        private readonly IZenviaConfiguration ZenviaConfiguration;

        public string from { get; set; }
        public string to { get; set; }
        public List<Template> contents { get; set; }
        public string callbackData { get; set; }
        public TemplateMessage()
        {

        }
        public TemplateMessage(string to, string campaignId, string flow, string payload, string language)
        {
            ZenviaConfiguration = new ZenviaConfiguration();
            this.from = ZenviaConfiguration.GetFromSenderIdByCampaign(campaignId);
            this.to = to;
            var templateId = ZenviaConfiguration.GetTemplateIdByCampaignAndFlow(campaignId, flow);
            var template = new Template("template",templateId, ZenviaConfiguration.GetTemplateFieldsByTemplateId(templateId), payload);
            //var template = new Template("template", "e3d3912a-ed29-4af6-98b1-bda646aab41b", "name,productName,deliveryDate", "Lucas,ProdTeste,10/12/2021");
            this.contents = new List<Template> {template};
            //this.contents.Add(template);
        }

    }
    public class Template
    {

        public string type { get; set; }
        public Guid templateId { get; set; }
        public Dictionary<string, string> fields { get; set; }

        public Template()
        {

        }

        public Template(string type, string templateId, string fields, string payload)
        {
            var fieldsList = fields.Split(",");
            var payloadList = payload.Split(",");
            var obj = new Dictionary<string, string>();

            for (int i = 0; i < fieldsList.Length; i++)
            {
                obj.Add(fieldsList[i], payloadList[i]);
            };

            this.type = type;
            this.templateId = Guid.Parse(templateId);
            this.fields = obj;


        }
    }
}



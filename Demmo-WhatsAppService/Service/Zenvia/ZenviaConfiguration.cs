using System;
using System.Collections.Generic;

namespace Demmo_WhatsAppService.Service.Zenvia
{
    public class ZenviaConfiguration : IZenviaConfiguration
    {
        /// <summary>
        /// Define o id do template de acordo com a campanha e fluxo.
        /// </summary>
        private readonly static Dictionary<string, string> _templateIds = new Dictionary<string, string>()
        {
           { "DEMMOZEN-SHIP", "e3d3912a-ed29-4af6-98b1-bda646aab41b" },
        };
        /// <summary>
        /// Retorna o nome do template de acordo com a campanha e fluxo.
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="flow"></param>
        /// <returns></returns>
        public string GetTemplateIdByCampaignAndFlow(string campaignId, string flow)
        {
            return _templateIds[String.Format("{0}-{1}", campaignId.ToUpper(), flow.ToUpper())];
        }
        /// <summary>
        /// Define o id do template de acordo com a campanha e fluxo.
        /// </summary>
        private readonly static Dictionary<string, string> _fields = new Dictionary<string, string>()
        {
           {"e3d3912a-ed29-4af6-98b1-bda646aab41b" , "name,productName,deliveryDate"},
        };
        /// <summary>
        /// Retorna o nome do template de acordo com a campanha e fluxo.
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="flow"></param>
        /// <returns></returns>
        public string GetTemplateFieldsByTemplateId(string templateId)
        {
            return _fields[templateId];
        }

        /// <summary>
        /// Define o numero do remetente de acordo com a campanha. 
        /// </summary>
        private readonly static Dictionary<string, string> _senderIdsFrom = new Dictionary<string, string>()
        {
           { "DEMMOZEN", "tough-ketch"},
        };
        /// <summary>
        /// Retorna o numero do remetente de acordo com a campanha. 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public string GetFromSenderIdByCampaign(string campaignId)
        {
            return _senderIdsFrom[campaignId.ToUpper()]; //From
        }

        /// <summary>
        /// Pega a API 
        /// </summary>
        /// <returns></returns>
        public string apiKey()
        {
           string key = "5rJUNeLA7LNyhR_HEktpoMmUE9-7QjtliaJL"; //todo pegar a apikey
           return key;
        }
        
        /// <summary>
        /// Pega a API 
        /// </summary>
        /// <returns></returns>
        public string UrlBase()
        {
            string url = "https://api.zenvia.com/v2/channels/whatsapp/messages";
            return url;
        }


    }
}

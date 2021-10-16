using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demmo_WhatsAppService.Service.Infobip
{
    public class InfobipConfiguration : IInfobipConfiguration
    {
        /// <summary>
        /// Define o nome do template de acordo com a campanha e fluxo.
        /// </summary>
        private readonly static Dictionary<string, string> _templateNames = new Dictionary<string, string>()
        {
           { "DEMMOINFO-MFA", "access_code" },
        };
        /// <summary>
        /// Retorna o nome do template de acordo com a campanha e fluxo.
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="flow"></param>
        /// <returns></returns>
        public string GetTemplateNameByCampaignAndFlow(string campaignId, string flow)
        {
            return _templateNames[String.Format("{0}-{1}", campaignId.ToUpper(), flow.ToUpper())];
        }

        /// <summary>
        /// Define o numero do remetente de acordo com a campanha. 
        /// </summary>
        private readonly static Dictionary<string, string> _numbersFrom = new Dictionary<string, string>()
        {
           { "DEMMOINFO", "447860099299" },
        };
        /// <summary>
        /// Retorna o numero do remetente de acordo com a campanha. 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public string GetFromNumberByCampaign(string campaignId)
        {
            return _numbersFrom[campaignId.ToUpper()]; //From
        }
        /// <summary>
        /// Define a url base de acordo com o tipo de mensagem
        /// </summary>
        private readonly static Dictionary<string, string> _baseUrls = new Dictionary<string, string>()
        {
           { "TemplateMessage", "https://{0}/whatsapp/1/message/template" },
           { "TextMessage", "https://{0}/whatsapp/1/message/text" },
        };

        /// <summary>
        /// Retorna a url base de acordo com o tipo de mensagem
        /// </summary>
        public string UrlBase(string type)
        {
            return _baseUrls[type];
        }

        /// <summary>
        /// Pega a API 
        /// </summary>
        /// <returns></returns>
        public string apiKey()
        {
            string key = "App ee147737b4e388a35348ee728a25c309-8f7b4399-2d2f-4218-9455-587f48a8bca1"; //todo pegar a apikey
            return key;
        }

        private readonly static Dictionary<string, string> _coreUrls = new Dictionary<string, string>()
        {
           { "DEMMOINFO", "5vpv9x.api.infobip.com" },
        };

        /// <summary>
        /// Retorna a urlCore por campaha
        /// </summary>
        /// <returns></returns>
        public string CoreUrl(string campaign)
        {
            return _coreUrls[campaign.ToUpper()];
        }
    }
}

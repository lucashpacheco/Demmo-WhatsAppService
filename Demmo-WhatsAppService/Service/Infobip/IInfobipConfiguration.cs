using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demmo_WhatsAppService.Service.Infobip
{
    public interface IInfobipConfiguration
    {
        string GetTemplateNameByCampaignAndFlow(string campaignId, string flow);

        string GetFromNumberByCampaign(string campaignId);
        string UrlBase(string type);
        string apiKey();
        string CoreUrl(string campaign);
    }
}

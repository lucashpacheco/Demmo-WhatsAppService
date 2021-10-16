using Demmo_WhatsAppService.Service.Infobip;
using Demmo_WhatsAppService.Service.Zenvia;
using System.Collections.Generic;

namespace Demmo_WhatsAppService.Service
{
    public class WhatsAppServiceFactory
    {
        public IInfobipConfiguration InfobipConfiguration { get; private set; }
        public WhatsAppServiceFactory(IInfobipConfiguration infobipConfiguration)
        {
            InfobipConfiguration = infobipConfiguration;

        }

        private readonly static Dictionary<string, IWhatsAppService> _campaigns = new Dictionary<string, IWhatsAppService>()
        {
           { "DEMMOINFO", new InfobipService(new InfobipConfiguration()) },
           { "DEMMOZEN", new ZenviaService(new ZenviaConfiguration()) },
        };
        public static IWhatsAppService CreateWhatsAppService(string campaignId)
        {
            return _campaigns[campaignId.ToUpper()];
        }
    }
}

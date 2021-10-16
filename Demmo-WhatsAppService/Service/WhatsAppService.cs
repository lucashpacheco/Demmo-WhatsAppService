using Demmo_WhatsAppService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demmo_WhatsAppService.Service
{
    public class WhatsAppService : IWhatsAppService
    {
        /// <summary>
        /// Chama o serviço responsavel pelo envio.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(List<WhatsAppRequest> message)
        {
            var senderEngine = WhatsAppServiceFactory.CreateWhatsAppService(message[0].CampaignId);

            await senderEngine.SendMessage(message);
        }
    }
}

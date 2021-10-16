using Demmo_WhatsAppService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demmo_WhatsAppService.Service
{
    public interface IWhatsAppService
    {
        public Task SendMessage(List<WhatsAppRequest> request);
    }
}

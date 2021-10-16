using Demmo_WhatsAppService.Models;
using System.Threading.Tasks;

namespace Demmo_WhatsAppService.Data
{
    public interface IWhatsAppRequestRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task SaveAsync(WhatsAppRequest request);
    }
}

using Demmo_WhatsAppService.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Demmo_WhatsAppService.Data

{
    public class WhatsAppRequestRepository : IWhatsAppRequestRepository
    {
        private readonly IMongoCollection<WhatsAppRequest> _whatsappRequestCollection = null;

        /// <summary>
        /// Cria uma nova instância de WhatsappRequestRepository
        /// </summary>
        public WhatsAppRequestRepository(IMongoDatabase database)
        {
            _whatsappRequestCollection = database.GetCollection<WhatsAppRequest>("WhatsAppRequest");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task SaveAsync(WhatsAppRequest request)
        {
            await _whatsappRequestCollection.ReplaceOneAsync(r => r.Id.Equals(request.Id), request, new ReplaceOptions { IsUpsert = true });
        }
    }
}

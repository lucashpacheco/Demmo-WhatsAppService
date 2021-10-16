using Demmo_WhatsAppService.Data;
using Demmo_WhatsAppService.Models;
using Demmo_WhatsAppService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demmo_WhatsAppService.Controllers
{
    [ApiController]
    [Route("api/whatsapp/")]
    public class WhatsAppController : Controller
    {
        private readonly ILogger<WhatsAppController> _logger;

        /// <summary>
        /// Repositório de request
        /// </summary>
        public IWhatsAppRequestRepository WhatsappRequestRepository { get; private set; }
        /// <summary>
        /// Camada de serviços
        /// </summary>
        public IWhatsAppService WhatsappService { get; private set; }

        /// <summary>
        /// Cria nova instância do controller WhatsAppMessage
        /// </summary>
        /// <param name="whatsappRequestRepository">Repositório de request Whatsapp</param>
        public WhatsAppController(IWhatsAppRequestRepository whatsappRequestRepository, IWhatsAppService whatsappService)
        {
            WhatsappService = whatsappService;
            WhatsappRequestRepository = whatsappRequestRepository;
        }


        /// <summary>
        /// Faz o envio de uma mensagem por WhatsApp
        /// </summary>
        /// <param name="rule">Requisição</param>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] List<WhatsAppRequest> requests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ModelErrors(ModelState));
            }
            await WhatsappService.SendMessage(requests);
            foreach (var request in requests)
            {
                await WhatsappRequestRepository.SaveAsync(request);
            }

            return Ok();


        }
    }
}

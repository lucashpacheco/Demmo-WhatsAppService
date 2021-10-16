using System.ComponentModel.DataAnnotations;

namespace Demmo_WhatsAppService.Models
{
    public class WhatsAppRequest
    {

        /// <summary>
        /// Identificador único da request.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Id { get; set; }

        /// <summary>
        /// Id da campanha
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string CampaignId { get; set; }

        /// <summary>
        /// Tipo de mensagem ( Template , Text , Audio , Video , ...)
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Type { get; set; }

        /// <summary>
        /// Fluxo remetente
        /// </summary>
        [Required]
        [MaxLength(5)]
        public string Flow { get; set; }

        /// <summary>
        /// Carga de dados a ser enviado ( placeholders , texto da mensagem , ...) 
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Payload { get; set; }

        /// <summary>
        /// Linguagem utilizada na mensagem
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Language { get; set; }

        /// <summary>
        /// Numero destinatario
        /// </summary>
        [Required]
        public string To { get; set; }
    }
}

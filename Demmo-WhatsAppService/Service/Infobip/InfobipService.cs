    using Demmo_WhatsAppService.Model.Infobip;
using Demmo_WhatsAppService.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Demmo_WhatsAppService.Service.Infobip
{
    public class InfobipService : IWhatsAppService
    {
        #region Dependecies
        /// <summary>
        /// Class with configutarion values for Infobip
        /// </summary>
        public IInfobipConfiguration InfobipConfiguration { get; private set; }
        public InfobipService(IInfobipConfiguration infobipConfiguration)
        {
            InfobipConfiguration = infobipConfiguration;
        }
        #endregion

        #region Conection with API
        /// <summary>
        /// Inicio o cliente de Rest
        /// </summary>
        /// <param name="fullUrl"></param>
        /// <returns></returns>
        private RestClient StartClient(string fullUrl)
        {
            RestClient client = new RestClient(fullUrl);
            client.Timeout = -1;
            return client;
        }

        /// <summary>
        /// Configura o cabeçalho da solitação
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        private RestRequest ConfigHeader(string authorization)
        {
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", authorization);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            return request;
        }
        #endregion

        #region Implementation

        /// <summary>
        /// Encaminha o fluxo para o metodo responsavel de acordo com o tipo de mensagem
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task SendMessage(List<WhatsAppRequest> requests)
        {
            switch (requests[0].Type)
            {
                case "TemplateMessage":
                    var messages = new ListTemplatesMessage();
                    messages.messages = new List<TemplateMessage>();
                    foreach(var request in requests)
                    {
                        var messageTemplate = new TemplateMessage(request.To, request.CampaignId, request.Flow, request.Payload, request.Language);
                        messages.messages.Add(messageTemplate);
                    }
                    await SendTemplateMessage(messages, requests[0].Type , requests[0].CampaignId);
                    break;
                case "TextMessage":
                    foreach (var request in requests)
                    {
                        var messageText = new TextMessage(request.CampaignId, request.To, request.Payload);
                        await SendTextMessage(messageText, request.Type, request.CampaignId);
                    }
                    
                    break;
                case "ImageMessage":
                    // TO BE IMPLEMENTED
                    break;
                case "AudioMessage":
                    // TO BE IMPLEMENTED
                    break;
                case "VideoMessage":
                    // TO BE IMPLEMENTED
                    break;
                case "DocumentMessage":
                    // TO BE IMPLEMENTED
                    break;
                case "StickerMessage":
                    // TO BE IMPLEMENTED
                    break;
                case "LocationMessage":
                    // TO BE IMPLEMENTED
                    break;
                case "ContactMessage":
                    // TO BE IMPLEMENTED
                    break;
                case "InsteractiveButtonsMessage":
                    // TO BE IMPLEMENTED
                    break;
            }

        }

        #endregion

        #region Private
        /// <summary>
        /// Motor de envio 
        /// </summary>
        /// <param name="json"></param>
        /// <param name="messageType"></param>
        /// <returns></returns>
        private async Task<IRestResponse> SenderEngine(string json, string messageType , string campaignId)
        {
            RestClient client = StartClient(String.Format(InfobipConfiguration.UrlBase(messageType), InfobipConfiguration.CoreUrl(campaignId)));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestRequest request = ConfigHeader(InfobipConfiguration.apiKey());
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = await client.ExecuteAsync(request);

            return response;
        }

        /// <summary>
        /// Envia as mensagens do tipo template 
        /// </summary>
        /// <param name="templateMessage"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private async Task<IRestResponse> SendTemplateMessage(ListTemplatesMessage templateMessage, string type , string campaignId)
        {
            var jsonStringResult = SimpleJson.SerializeObject(templateMessage);
            IRestResponse response = await SenderEngine(jsonStringResult, type , campaignId);

            return response;
        }

        /// <summary>
        /// Envia as mensagens do tipo text
        /// </summary>
        /// <param name="textMessage"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private async Task<IRestResponse> SendTextMessage(TextMessage textMessage, string type, string campaignId)
        {
            var jsonStringResult = SimpleJson.SerializeObject(textMessage);
            IRestResponse response = await SenderEngine(jsonStringResult, type , campaignId);
            return response;
        }
        #endregion
    }
}

namespace Demmo_WhatsAppService.Service.Zenvia
{
    public interface IZenviaConfiguration
    {
        string GetTemplateIdByCampaignAndFlow(string campaignId, string flow);
        string GetTemplateFieldsByTemplateId(string templateId);
        string GetFromSenderIdByCampaign(string campaignId);
        string apiKey();
        string UrlBase();
    }
}

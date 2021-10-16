using Demmo_WhatsAppService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Demmo_WhatsAppService.Data.MongoDb
{
    /// <summary>
    /// Extensões para configurar Dependency Injection para os repositórios do MongoDb.
    /// </summary>
    public static class DummyConfigurationExtensions
    {

        /// <summary>
        /// Utiliza MongoDb como layer de persistência.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static void UseMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            // fix decimal serialized as string
            BsonSerializer.RegisterSerializer(typeof(decimal), new DecimalSerializer(BsonType.Decimal128));
            BsonSerializer.RegisterSerializer(typeof(decimal?), new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));

            var settings = new MongoDbSettings();
            configuration.GetSection("MongoDbSettings").Bind(settings);

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);

            CreateIndexes(database);

            services.AddSingleton(settings);
            services.AddSingleton(client);
            services.AddSingleton(database);

            services.AddTransient<IWhatsAppRequestRepository, WhatsAppRequestRepository>();
        }

        private static void CreateIndexes(IMongoDatabase database)
        {
            var rule = database.GetCollection<WhatsAppRequest>("WhatsAppRequest");
            rule.Indexes.CreateMany(new List<CreateIndexModel<WhatsAppRequest>> {
                new CreateIndexModel<WhatsAppRequest>(Builders<WhatsAppRequest>.IndexKeys.Ascending(r => r.CampaignId)),
                new CreateIndexModel<WhatsAppRequest>(Builders<WhatsAppRequest>.IndexKeys.Ascending(r => r.CampaignId).Ascending(r => r.Id), new CreateIndexOptions { Unique = true })
            });
        }

    }
}

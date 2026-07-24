using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Wallet.BLL.Logic.Contracts.Kafka;

namespace Wallet.BLL.Logic.Kafka
{
    public class KafkaProducer<TValue> : IKafkaProducer<TValue>
    {
        private readonly ILogger<KafkaProducer<TValue>> _logger;
        private readonly ProducerConfig _config;

        public KafkaProducer(ILogger<KafkaProducer<TValue>> logger, string bootstrapServers)
        {
            _logger = logger;
            _config = new ProducerConfig { BootstrapServers = bootstrapServers };
        }

        public async Task ProduceAsync(string topic, TValue message)
        {
            try
            {
                // Сериализуем объект в JSON
                var jsonString = JsonSerializer.Serialize(message);

                // Создаём продюсера с ключом типа Null (без ключа)
                using (var producer = new ProducerBuilder<Null, string>(_config)
                    .SetValueSerializer(Serializers.Utf8)   // отправляем как строку UTF-8
                    .Build())
                {
                    var result = await producer.ProduceAsync(topic,
                        new Message<Null, string> { Value = jsonString });

                    _logger.LogInformation($"Message produced to {result.TopicPartitionOffset}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while producing the message.");
                throw; // пробрасываем дальше, чтобы вызывающий код знал об ошибке
            }
        }
    }
}
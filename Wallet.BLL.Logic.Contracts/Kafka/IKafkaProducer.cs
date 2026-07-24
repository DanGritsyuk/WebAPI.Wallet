namespace Wallet.BLL.Logic.Contracts.Kafka
{
    public interface IKafkaProducer<TValue>
    {
        Task ProduceAsync(string topic, TValue message);
    }
}
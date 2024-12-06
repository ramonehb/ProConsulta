namespace ProConsulta.Service
{
    public interface IBusService
    {
        void Publish<T>(string routingKey, T message);
    }
}

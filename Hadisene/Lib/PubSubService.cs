using StackExchange.Redis;

namespace Hadisene.Lib;
public class PubSubService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public PubSubService(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public void Subscribe(RedisChannel channel, Action<RedisChannel, RedisValue> msgHndlr)
    {
        var sub = _connectionMultiplexer.GetSubscriber();
        sub.Subscribe(channel, msgHndlr);
        //subscriber.Subscribe(channel, (channel, message) => messageHandler(message));
    }

    public void Unsubscribe(RedisChannel channel, Action<RedisChannel,RedisValue> msgHndlr)
    {
        var sub = _connectionMultiplexer.GetSubscriber();
        sub.Unsubscribe(channel, msgHndlr, CommandFlags.FireAndForget);
    }

    public void Publish(RedisChannel channel, string message)
    {
        var sub = _connectionMultiplexer.GetSubscriber();
        sub.Publish(channel, message);
    }
}

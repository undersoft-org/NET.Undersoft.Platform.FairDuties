using System.Threading.Tasks;

namespace UltimatR
{
    public interface IEventHandler<in TEvent> : IEventHandler
    {
        Task HandleEventAsync(TEvent eventData);
    }

    public interface IEventHandler
    {

    }
}

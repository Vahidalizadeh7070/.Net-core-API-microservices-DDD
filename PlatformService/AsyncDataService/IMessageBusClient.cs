using PlatformService.DTO;

namespace PlaformServices.AsyncDataService
{
    public interface IMessageBusClient
    {
        void PublishNewPlatform(PlatformPublishedDto platformPublishedDto);
    }
}
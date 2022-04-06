using System.Threading.Tasks;
using PlatformService.DTO;

namespace PlaformServices.SyncDataServices.http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDTO plat);
    }
}
using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        public IEnumerable<Platforms> GetAllPlatforms();
        public Platforms GetPlatformById(int id);
        void CreatePlatform(Platforms plat);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo:IPlatformRepo
    {
        private readonly AppDbContext _context;
        public PlatformRepo(AppDbContext context)
        {
            _context=context;
        }
        
        public IEnumerable<Platforms> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platforms GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p=>p.Id==id);
        }

        public void CreatePlatform(Platforms plat)
        {
            if (plat==null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Platforms.Add(plat);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }
    }
}
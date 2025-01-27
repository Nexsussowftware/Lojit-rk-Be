using Data;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;

        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

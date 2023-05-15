using Repositories.Abstract;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationContext _context;
        private readonly Lazy<IStaffRepository> _staffRepository;

        public RepositoryManager(ApplicationContext context)
        {
            _context = context;
            _staffRepository = new Lazy<IStaffRepository>(() => new StaffRepository(_context));
        }
        
        public IStaffRepository Staff=> _staffRepository.Value;
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

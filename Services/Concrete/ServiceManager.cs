using Repositories.Abstract;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStaffService> _staffService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _staffService = new Lazy<IStaffService>(() => new StaffManager(repositoryManager));
        }

        public IStaffService StaffService => _staffService.Value;
    }
}

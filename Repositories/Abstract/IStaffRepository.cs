using Entities.Models;
using System.Linq.Expressions;

namespace Repositories.Abstract
{
    public interface IStaffRepository:IRepositoryBase<Staff>
    {
        IQueryable<Staff> GetAllStaffs(bool trankChanges);
        Staff GetOneStaffById(int id, bool trankChanges);
        void CreateOneStaff(Staff staff);
        void DeleteOneStaff(Staff staff);
        void UpdateOneStaff(Staff staff);
        bool IsEmailUnique(string email);
        bool Any(Expression<Func<Staff, bool>> filter = null);
        List<Staff> GetStaffCityCountry(string cityName, string countryName);
     

    }
}

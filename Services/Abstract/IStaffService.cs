using Entities.Models;

namespace Services.Abstract
{
    public interface IStaffService
    {
        IEnumerable<Staff> GetAllStaffs(bool trackChanges);
        Staff GetOneStaffById(int id, bool trackChanges);
        Staff CreateOneStaff(Staff staff);
        void UpdateOneStaff(int id, Staff staff, bool trackChanges);
        void DeleteOneStaff(int id, bool trackChanges);
        bool IsEmailUnique(string email);
        List<Staff> GetStaffCityCountry(string cityName,string countryName);
       

    }
}

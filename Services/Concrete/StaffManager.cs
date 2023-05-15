using Entities.Models;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IRepositoryManager _manager;
        public StaffManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public Staff CreateOneStaff(Staff staff)
        {
            if (staff is null)
                throw new ArgumentNullException(nameof(staff));
            if (!IsEmailUnique(staff.Email))
            {
                throw new Exception("Email field must be unique");
            }
            _manager.Staff.CreateOneStaff(staff);
            _manager.Save();
            return staff;
        }

        public void DeleteOneStaff(int id, bool trackChanges)
        {
            var entity = _manager.Staff.GetOneStaffById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Staff with id:{id} could not found.");
            _manager.Staff.DeleteOneStaff(entity);
            _manager.Save();
        }

        public IEnumerable<Staff> GetAllStaffs(bool trackChanges)
        {
            return _manager.Staff.GetAllStaffs(trackChanges);
        }

        public Staff GetOneStaffById(int id, bool trackChanges)
        {
            return _manager.Staff.GetOneStaffById(id, trackChanges);
        }

        public List<Staff> GetStaffCityCountry(string cityName, string countryName)
        {
            return _manager.Staff.GetStaffCityCountry(cityName, countryName);
        }


        public bool IsEmailUnique(string email)
        {
            return !_manager.Staff.Any(s => s.Email == email);
        }

        public void UpdateOneStaff(int id, Staff staff, bool trackChanges)
        {
            var entity = _manager.Staff.GetOneStaffById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Staff with id:{id} could not found.");

            if (staff is null)
                throw new ArgumentNullException(nameof(staff));
       
            entity.Id= id;
            entity.FirstName = staff.FirstName;
            entity.LastName = staff.LastName;
            entity.Email = staff.Email;
            entity.Phone = staff.Phone;
            entity.DateOfBirth = staff.DateOfBirth;
            entity.City = staff.City;
            entity.Country = staff.Country;
            entity.Province = staff.Province;
            entity.AddressLine1= staff.AddressLine1;
         
            _manager.Staff.UpdateOneStaff(entity);
            _manager.Save();
        }
    }
}

using Entities.Models;
using Repositories.Abstract;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repositories.EfCore
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        public StaffRepository(ApplicationContext context) : base(context)
        {

        }

        public void CreateOneStaff(Staff staff) => Create(staff);

        public void DeleteOneStaff(Staff staff) => Delete(staff);

        public IQueryable<Staff> GetAllStaffs(bool trankChanges)
        {
            return FindAll(trankChanges).OrderBy(x => x.Id);

        }

        public Staff GetOneStaffById(int id, bool trankChanges)
        {
            return FindByCondition(x => x.Id == id, trankChanges).SingleOrDefault();

        }

        public bool IsEmailUnique(string email)
        {
            return !_context.Staffs.Any(s => s.Email == email);
        }

        public void UpdateOneStaff(Staff staff) => Update(staff);
        public bool Any(Expression<Func<Staff, bool>> expression)
        {
            return _context.Set<Staff>().Any(expression);
        }

       

       public List<Staff> GetStaffCityCountry(string cityName, string countryName)
        {
            return _context.Set<Staff>().Where(c => c.City==cityName &&c.Country== countryName).ToList();
        }

     
    }
}

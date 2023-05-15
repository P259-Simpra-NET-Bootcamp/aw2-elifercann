namespace Repositories.Abstract
{
    public interface IRepositoryManager
    {
        IStaffRepository Staff { get; }
        void Save();

    }
}

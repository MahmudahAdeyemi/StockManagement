using file.Entities;

namespace file.Interfaces.Repositoritories
{
    public interface IAdminRepository
    {
        void SaveAdmins(List<Admin> admins);
        List<Admin>? GetAllAdmins();
        void Add();
    }
}
using DatabaseHomework.Models;

namespace DatabaseHomework.Repository
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartment(int id);
        Task<IEnumerable<Department>> GetAllDepartments();
        Task AddDepartment(Department country);
        Task<Department> UpdateDepartment(Department country);
        Task<Department> DeleteDepartment(int id);
    }
}

using DatabaseHomework.DbProvider;
using DatabaseHomework.Models;

namespace DatabaseHomework.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDapperDbProvider _dapperDbProvider;

    private const string SelectDepartmentSqlStatement = @"SELECT * FROM department WHERE DepartmentId = @Id LIMIT 1";
    private const string SelectAllDepartmentsSqlStatement = @"SELECT * FROM department LIMIT 50";

    public DepartmentRepository(IDapperDbProvider dapperDbProvider)
    {
        _dapperDbProvider = dapperDbProvider;
    }

    public async Task<Department> GetDepartment(int id)
    {
        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryFirstOrDefaultAsync<Department>(connection, SelectDepartmentSqlStatement, new { Id = id });
    }

    public async Task<IEnumerable<Department>> GetAllDepartments()
    {
        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryAsync<Department>(connection, SelectAllDepartmentsSqlStatement);
    }

    public async Task AddDepartment(Department department)
    {
        string InsertDepartmentSqlStatement = $"INSERT INTO public.department(departmentid, deptname, countryid) VALUES ('{department.DepartmentId}', '{department.DeptName}', '{department.CountryId}');";

        using var connection = _dapperDbProvider.GetConnection();

        await _dapperDbProvider.ExecuteAsync(connection, InsertDepartmentSqlStatement);
    }

    public async Task<Department> UpdateDepartment(Department department)
    {
        string UpdateDepartmentSqlStatement = $"UPDATE public.department SET departmentid ={department.DepartmentId}, deptname = '{department.DeptName}' , countryid = {department.CountryId} WHERE DepartmentId = {department.DepartmentId}";

        using var connection = _dapperDbProvider.GetConnection();

        return await _dapperDbProvider.QueryFirstOrDefaultAsync<Department>(connection, UpdateDepartmentSqlStatement);
    }

    public async Task<Department> DeleteDepartment(int id)
    {
        string DeleteDepartmentSqlStatement = $"DELETE FROM public.department WHERE departmentid = {id};";
        using var connection = _dapperDbProvider.GetConnection();
        await _dapperDbProvider.QueryFirstOrDefaultAsync<Department>(connection, DeleteDepartmentSqlStatement);
        return await _dapperDbProvider.QueryFirstOrDefaultAsync<Department>(connection, SelectDepartmentSqlStatement, new { Id = id });
    }
}
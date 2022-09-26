using DatabaseHomework.DbProvider;
using DatabaseHomework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHomework.Controllers;

[Route("[controller]s")]
[ApiController]
public class EmployeeController : ControllerBase
{

    private readonly PatikaDbContext _patikaDbContext;

    public EmployeeController(PatikaDbContext patikaDbContext)
    {
        _patikaDbContext = patikaDbContext;
    }

    [HttpGet("GetEmployee")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        Employee employee = await _patikaDbContext.Employee.Where(x => x.empid == id).FirstOrDefaultAsync();
        if (employee == null) return NotFound();

        return Ok(employee);
    }

    [HttpGet("GetEmployees")]
    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        IEnumerable<Employee> employees = await _patikaDbContext.Employee.ToListAsync();
        return employees;
    }

    [HttpPut("ChangeEmployeeName")]
    public async Task<IActionResult> ChangeEmployeeName(int id, string newName)
    {
        Employee employee = await _patikaDbContext.Employee.Where(x => x.empid == id).FirstOrDefaultAsync();
        if (employee == null) return NotFound();
        employee.empname = newName;
        await _patikaDbContext.SaveChangesAsync();
        return Ok(employee);
    }

    [HttpPost("AddNewEmployee")]
    public async Task<IActionResult> AddNewEmployee([FromQuery] Employee employee)
    {
        await _patikaDbContext.AddAsync(employee);
        await _patikaDbContext.SaveChangesAsync();
        return Ok(employee);
    }

    [HttpDelete("DeleteEmployee")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        Employee employee = await _patikaDbContext.Employee.Where(x => x.empid == id).FirstOrDefaultAsync();
        if (employee == null) return NotFound();
        _patikaDbContext.Remove(employee);
        await _patikaDbContext.SaveChangesAsync();
        return Ok(employee);
    }
}
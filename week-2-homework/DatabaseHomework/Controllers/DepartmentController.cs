using DatabaseHomework.Models;
using DatabaseHomework.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseHomework.Controllers;

[Route("departments")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _departmentRepository;


    public DepartmentController(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    [HttpGet("GetDepartment/{id}")]
    public async Task<IActionResult> GetDepartment(int id)
    {
        Department department = await _departmentRepository.GetDepartment(id);
        if (department == null) return NotFound();
        return Ok(department);
    }

    [HttpGet("GetDepartments")]
    public async Task<IActionResult> GetAllDepartments()
    {
        IEnumerable<Department> departments = await _departmentRepository.GetAllDepartments();
        return Ok(departments);
    }

    [HttpPut("UpdateDepartment")]
    public async Task<IActionResult> UpdateDepartment([FromQuery] Department department)
    {
        _departmentRepository.UpdateDepartment(department);
        return Ok(department);
    }

    [HttpPost("AddNewDepartment")]
    public async Task<IActionResult> AddNewDepartment([FromQuery] Department department)
    {
        _departmentRepository.AddDepartment(department);
        return Ok(department);
    }

    [HttpDelete("DeleteDepartment/{id}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        Department department = await _departmentRepository.GetDepartment(id);
        _departmentRepository.DeleteDepartment(id);
        return Ok(department);
    }
}

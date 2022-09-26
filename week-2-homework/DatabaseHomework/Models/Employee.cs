using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseHomework.Models;

[Table("employee")]
public class Employee
{
    [Key]
    [Column("empid")]
    public int empid { get; set; }
    [Column("empname")]
    public string empname { get; set; }
    [Column("deptid")]
    public int deptid { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseHomework.Models;


[Table("folder")]
public class Folder
{
    [Column("folderid")]    
    public int folderid { get; set; }

    [Column("empid")]
    public int empid { get; set; }

    [Column("accesstype")]
    public string accesstype{ get; set; } 
    
}
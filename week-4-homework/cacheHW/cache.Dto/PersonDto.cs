using cacheHW.Base;
using System.ComponentModel.DataAnnotations;

namespace cacheHW.Dto
{
    public class PersonDto
    {

        [Required]
        [MaxLength(25)]
        [Display(Name = "AccountId")]
        public string accountid { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Phone]
        [MaxLength(25)]
        public string Phone { get; set; }

        [Required]
        [DateOfBirth]
        [DataType(DataType.Date)]
        [Display(Name = "DateOfBirth")]
        public DateTime dateofbirth { get; set; }
    }
}

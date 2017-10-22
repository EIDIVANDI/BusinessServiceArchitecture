using System.ComponentModel.DataAnnotations;

namespace BusinessServiceArchitecture_Domain.User
{
    public class UserModel
    {

        [Required]
        [StringLength(50, MinimumLength =2)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
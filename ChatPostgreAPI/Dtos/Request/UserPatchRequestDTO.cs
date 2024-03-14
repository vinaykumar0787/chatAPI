using System.ComponentModel.DataAnnotations;

namespace ChatPostgreAPI.Dtos.Request
{
    public class UserPatchRequestDTO
    {
        [MaxLength(15)]
        [Required(ErrorMessage = "Phone Number Required.")]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Name is Required.")]
        public string UserName { get; set; }
    }
}

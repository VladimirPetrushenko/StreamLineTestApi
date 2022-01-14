using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.Users
{
    public class UserCreateDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}

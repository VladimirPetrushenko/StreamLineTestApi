using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.Test
{
    public class TestDeleteDto
    {
        [Required]
        public int Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamLineTestApi.Client.Models.Dto.Test
{
    public class TestCheckResultDto
    {
        public int Id { get; set; }
        public List<string> Answers { get; set; }
    }
}

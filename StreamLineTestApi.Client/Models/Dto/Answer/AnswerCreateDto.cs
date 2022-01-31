﻿using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.Answer
{
    public class AnswerCreateDto
    {
        public int? Id { get; set; }
        public string Value { get; set; }
        [Required]
        public bool IsRight { get; set; }
    }
}

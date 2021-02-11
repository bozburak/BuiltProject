using System.Collections.Generic;

namespace MultiTierProject.Core.AutoMapper.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }
        public int Status { get; set; }
    }
}

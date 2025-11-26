using System.ComponentModel.DataAnnotations;

namespace TodoCleanArch.Application.DTOs
{
    public class CreateTodoDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
    }
}

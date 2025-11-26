using System.ComponentModel.DataAnnotations;

namespace TodoCleanArch.Application.DTOs
{
    public class UpdateTodoDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}

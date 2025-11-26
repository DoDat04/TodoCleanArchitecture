using System;
using System.Collections.Generic;

namespace TodoCleanArch.Domain.Entities;

public partial class TodoItem
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public bool IsCompleted { get; set; }

    public DateTime? CreatedAt { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace task_api.Models;

public class Tasks
{
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public bool Completed { get; set; }
}
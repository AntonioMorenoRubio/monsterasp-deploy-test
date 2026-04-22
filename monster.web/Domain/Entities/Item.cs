using System.ComponentModel.DataAnnotations;

namespace monster.web.Domain.Entities;

public class Item
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(50)] public string Name { get; init; } = String.Empty;
    [Required] public int Price { get; set; }
}
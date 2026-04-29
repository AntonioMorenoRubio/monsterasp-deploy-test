using System.ComponentModel.DataAnnotations;

namespace monster.web.Domain.Entities;

public class Jugador
{
    [Key] public int Id { get; set; }
    public string Nickname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int? WargamingId { get; set; }
}
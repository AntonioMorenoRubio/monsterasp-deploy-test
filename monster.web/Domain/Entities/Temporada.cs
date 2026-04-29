using System.ComponentModel.DataAnnotations;

namespace monster.web.Domain.Entities;

public class Temporada
{
    [Key] public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public bool Activa { get; set; }
}
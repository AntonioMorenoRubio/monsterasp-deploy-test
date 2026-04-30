using System.ComponentModel.DataAnnotations;
using monster.web.Controllers;

namespace monster.web.Domain.Entities;

public class Barco
{
    [Key] public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Nacion { get; set; } = string.Empty;
    public int Nivel { get; set; }
    public TipoBarco Tipo { get; set; } = TipoBarco.Destructor;
}
namespace PortalGalaxy.Entities;

public class Taller : EntityBase
{
    public string Nombre { get; set; } = default!;
    public Categoria Categoria { get; set; } = default!;
    public int CategoriaId { get; set; }
    public Instructor Instructor { get; set; } = default!;
    public int InstructorId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime HoraInicio { get; set; }
    public SituacionTaller Situacion { get; set; }
    public string? PortadaUrl { get; set; }
    public string? TemarioUrl { get; set; }

    public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
}
namespace PortalGalaxy.Entities
{
    public class Categoria : EntityBase
    {
        public string Nombre { get; set; } = default!;
        public DateTime Hora { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return Nombre;
        }

    }
}
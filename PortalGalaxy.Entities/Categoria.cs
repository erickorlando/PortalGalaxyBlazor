namespace PortalGalaxy.Entities
{
    public class Categoria : EntityBase
    {
        public string Nombre { get; set; } = default!;

        public override string ToString()
        {
            return Nombre;
        }
    }
}
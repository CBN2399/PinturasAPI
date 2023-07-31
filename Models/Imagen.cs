namespace PinturasAPI.Models
{
    public class Imagen
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Descripcion { get; set; }

        public Tipo tipo { get; set; }
    }
}

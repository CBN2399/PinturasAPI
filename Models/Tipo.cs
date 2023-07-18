namespace PinturasAPI.Models
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Imagen> Imagenes { get; set;}
    }
}

namespace PinturasAPI.Models
{
    public class Imagen
    {
        public int Id { get; set; }

        public byte[] ImgData { get; set; }
        public string Descripcion { get; set; }

        public Tipo tipo { get; set; }
    }
}

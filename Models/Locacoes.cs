namespace LocadoraZe.Api.Models
{
    public class Locacoes
    {
        public int Id { get; set; }
        public DateTime Dataretirada { get; set; }

        public int ClienteId { get; set; }
        public int PatineteId { get; set; }

    }
}

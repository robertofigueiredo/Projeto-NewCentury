namespace WebUI.Models
{
    public class AdivinhaInteiro
    {
        public int Id { get; set; }
        public int COD_JOGADOR { get; set; }
        public int NUM_TENTATIVA { get; set; }
        public DateTime HorarioJogo { get; set; }
        public string Resultado { get; set; }
    }
}

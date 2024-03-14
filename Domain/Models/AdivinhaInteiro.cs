using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AdivinhaInteiro
    {
        [Key]
        public int Id { get; set; }
        public int COD_JOGADOR {  get; set; }
        public int NUM_TENTATIVA {  get; set; }
        public DateTime HorarioJogo { get; set; }
        public string Resultado { get; set; }
    }
}

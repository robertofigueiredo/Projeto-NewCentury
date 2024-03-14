using Domain.Models;

namespace Services.Services
{
    public interface IServicesAdivinhaInteiro
    {
        IEnumerable<AdivinhaInteiro> BuscaHistoricoJogador(int Jogador);
        IEnumerable<AdivinhaInteiro> BuscaHistoricoGeral();
        void LimpaHistorico();
        string ConfirmarJogada(int numeroJogador, int palpitejogador);
    }
}


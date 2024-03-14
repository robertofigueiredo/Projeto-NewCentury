using Domain.Context;
using Domain.Models;

namespace Domain.Repositories
{
    public class AdivinhaInteiroRepository
    {
        //Dentro do repository, deixei ele limpo e sem regra de negócio, apenas meu contexto e requisições do SQLite
        private readonly ContextoJogo _contexto;
        public AdivinhaInteiroRepository(ContextoJogo contexto)
        {
            _contexto = contexto;
        }

        #region Métodos Repository
        public IEnumerable<AdivinhaInteiro> BuscaHistoricoJogador(int jogador)
        {
            var DadosLista = _contexto.AdivinhaInteiro.Where(rr => rr.COD_JOGADOR == jogador).ToList();
            return DadosLista;
        }

        public IEnumerable<AdivinhaInteiro> BuscaHistoricoGeral()
        {
            var DadosLista = _contexto.AdivinhaInteiro.ToList();
            return DadosLista;
        }

        public void LimpaHistorico()
        {
            var LimpaHistorico = _contexto.AdivinhaInteiro.ToList();
            foreach (var item in LimpaHistorico)
            {
                _contexto.Remove(item);
                _contexto.SaveChanges();
            }
        }

        public bool AumentoTentativa(int numeroJogador, string resultado, int indice)
        {
            var jogadorNovo = EncontrarJogadorNovo(numeroJogador);
            var ultimoJogador = EncontrarUltimoJogador(numeroJogador);

            if (jogadorNovo != null && indice == 1)
            {
                AdicionarNovaTentativa(jogadorNovo.COD_JOGADOR, jogadorNovo.NUM_TENTATIVA + 1, resultado);
                RemoverJogadorSeNovo(jogadorNovo);
                return true;
            }
            else if (ultimoJogador != null)
            {
                AdicionarNovaTentativa(ultimoJogador.COD_JOGADOR, ultimoJogador.NUM_TENTATIVA + 1, resultado);
                return true;
            }
            else
            {
                AdicionarNovaTentativa(numeroJogador, 1, resultado);
                return true;
            }
        }

        private AdivinhaInteiro EncontrarJogadorNovo(int numeroJogador)
        {
            return _contexto.AdivinhaInteiro.FirstOrDefault(rr => rr.COD_JOGADOR == numeroJogador && rr.Resultado == "Novo");
        }

        private AdivinhaInteiro EncontrarUltimoJogador(int numeroJogador)
        {
            return _contexto.AdivinhaInteiro.Where(rr => rr.COD_JOGADOR == numeroJogador)
                                             .OrderByDescending(rr => rr.NUM_TENTATIVA)
                                             .FirstOrDefault();
        }

        private void AdicionarNovaTentativa(int codJogador, int numTentativa, string resultado)
        {
            var novaTentativa = new AdivinhaInteiro
            {
                COD_JOGADOR = codJogador,
                NUM_TENTATIVA = numTentativa,
                Resultado = resultado,
                HorarioJogo = DateTime.Now
            };

            _contexto.AdivinhaInteiro.Add(novaTentativa);
            _contexto.SaveChanges();
        }

        private void RemoverJogadorSeNovo(AdivinhaInteiro jogador)
        {
            if (jogador.Resultado == "Novo")
            {
                _contexto.AdivinhaInteiro.Remove(jogador);
                _contexto.SaveChanges();
            }
        }

        public List<AdivinhaInteiro> ObterJogador(int jogador)
        {
            var dadosJogador = _contexto.AdivinhaInteiro
                .Where(rr => rr.COD_JOGADOR == jogador)
                .ToList();

            return dadosJogador;
        }

        public bool JogadorExiste(int jogador)
        {
            var BuscaJogador = _contexto.AdivinhaInteiro.FirstOrDefault(rr => rr.COD_JOGADOR == jogador);
            if (BuscaJogador == null)
            {
                return false;
            }
            return true;
        }

        public bool IncluirJogador(AdivinhaInteiro NovoJogador)
        {
            try
            {
                _contexto.AdivinhaInteiro.Add(NovoJogador);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion
    }
}

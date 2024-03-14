using Domain.Models;
using Domain.Repositories;
using Services.Enums;

namespace Services.Services
{
    public class ServicesAdivinhaInteiro : IServicesAdivinhaInteiro
    {
        //Essa camada Services, é utilizada para implementar a regra de negócio do projeto
        private AdivinhaInteiroRepository _repository;
        public ServicesAdivinhaInteiro(AdivinhaInteiroRepository repository)
        {
            _repository = repository;
        }

        #region Busca Histórico Jogador
        public IEnumerable<AdivinhaInteiro> BuscaHistoricoJogador(int Jogador)
        {
            var buscaRepository = _repository.BuscaHistoricoJogador(Jogador).ToList();
            return buscaRepository;
        }
        #endregion

        #region Busca Histórico Geral
        public IEnumerable<AdivinhaInteiro> BuscaHistoricoGeral()
        {
            var buscaRepository = _repository.BuscaHistoricoGeral().ToList();

            var dadosAgrupados = buscaRepository
                .GroupBy(rr => rr.COD_JOGADOR)
                .Select(group => new
                {
                    COD_JOGADOR = group.Key,
                    NUM_TENTATIVA = group.Count(),
                    HorarioJogo = group.Select(rr => rr.HorarioJogo).FirstOrDefault(),
                });

            var DadosLimpos = dadosAgrupados.Select(rr => new AdivinhaInteiro
            {
                COD_JOGADOR = rr.COD_JOGADOR,
                NUM_TENTATIVA = rr.NUM_TENTATIVA,
                HorarioJogo = rr.HorarioJogo,
                Resultado = ObterRank(rr.COD_JOGADOR)
            });

            return DadosLimpos;
        }
        #endregion

        #region Limpa Histórico de Jogadas
        public void LimpaHistorico()
        {
            _repository.LimpaHistorico();
        }
        #endregion

        #region Array de Ranks
        public static Rank[] Ranks = new Rank[]
        {
            new Rank(80, 100, "A"),
            new Rank(60, 79, "B"),
            new Rank(40, 59, "C"),
            new Rank(20, 39, "D"),
            new Rank(0, 19, "E"),
        };
        #endregion

        #region Calculo da porcentagem de Vitoria
        public double CalcularPorcentagemDeVitoria(List<AdivinhaInteiro> jogador)
        {
            int totalJogos = jogador.Count;
            if (totalJogos == 0)
                return 0;

            int sucesso = jogador.Count(rr => rr.Resultado == "SUCCESS");
            return (double)sucesso / totalJogos * 100;
        }
        #endregion

        #region Obter Rank Jogador
        //Aqui eu obtenho o rank com base na quantidade de jogadas feitas
        public string ObterRank(int numeroJogador)
        {
            var jogador = _repository.ObterJogador(numeroJogador);
            var porcentagemDeVitoria = CalcularPorcentagemDeVitoria(jogador);

            foreach (var rank in Ranks)
            {
                if (porcentagemDeVitoria >= rank.Minimo && porcentagemDeVitoria <= rank.Maximo)
                {
                    return rank.Descricao;
                }
            }

            return "Sem Rank";
        }
        #endregion

        #region Confirma Jogada
        /// <summary>
        /// Metodo onde é confirmado a jogada do usuario, onde eu incluo um usuario caso não houver e com isso
        /// posteriormente atualizo sua jogada, gero um numero de 1 a 100 e utilizo o EnumResultados
        /// </summary>
        /// <param name="numeroJogador"></param>
        /// <param name="palpitejogador"></param>
        /// <returns></returns>
        public string ConfirmarJogada(int numeroJogador, int palpitejogador)
        {
            string retorno = string.Empty;
            try
            {
                int indice = 0;
                bool AumentoTentativa = false;
                Random random = new Random();
                int NumeroGerado = random.Next(0, 101);
                var rank = string.Empty;
                var JogadorExiste = _repository.JogadorExiste(numeroJogador);
                if (!JogadorExiste)
                {
                    var NovoJogador = new AdivinhaInteiro
                    {
                        COD_JOGADOR = numeroJogador,
                        NUM_TENTATIVA = 0,
                        Resultado = "Novo",
                        HorarioJogo = DateTime.Now,
                    };
                    var IncluirJogador = _repository.IncluirJogador(NovoJogador);

                    if (NumeroGerado == palpitejogador)
                    {
                        return retorno = Enums.EnumResultado.SUCCESS.ToString();
                    }
                    retorno = Enums.EnumResultado.WRONG.ToString();
                    indice = 1;
                    AumentoTentativa = _repository.AumentoTentativa(numeroJogador, retorno, indice);
                    rank = ObterRank(numeroJogador);

                    return retorno;
                }
                if (NumeroGerado == palpitejogador)
                {
                    retorno = Enums.EnumResultado.SUCCESS.ToString();
                    AumentoTentativa = _repository.AumentoTentativa(numeroJogador, retorno, indice);
                    rank = ObterRank(numeroJogador);
                    return retorno;
                }
                retorno = Enums.EnumResultado.WRONG.ToString();
                AumentoTentativa = _repository.AumentoTentativa(numeroJogador, retorno, indice);
                rank = ObterRank(numeroJogador);
            }
            catch (Exception ex)
            {
                return retorno = "erro";
                throw ex;
            }

            return retorno;
        }

        #endregion

    }
}

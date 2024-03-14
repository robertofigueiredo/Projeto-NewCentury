using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace WebUI.Controllers
{
    public class AdivinhaInteiroController : Controller
    {
        private IServicesAdivinhaInteiro _services;

        /// <summary>
        /// A camada da controller eu utilizei apenas para fazer as requisições para o services
        /// aumentando a segurança e melhorando arquitetura do projeto
        /// </summary>
        public AdivinhaInteiroController(IServicesAdivinhaInteiro service)
        {
            _services = service;
        }

        #region Métodos Controller
        public IActionResult Index()
        {
            return View("../AdivinhaInteiro/Index");
        }

        public IActionResult HistoricoJogador()
        {
            return View("../AdivinhaInteiro/HistoricoJogador");
        }
        public IActionResult NovoJogo()
        {
            return View("../AdivinhaInteiro/NovoJogo");
        }

        public IEnumerable<AdivinhaInteiro> BuscaHistoricoJogador(int numeroJogador)
        {
            var retornoPesquisa = _services.BuscaHistoricoJogador(numeroJogador).ToList();
            return retornoPesquisa;
        }

        public IEnumerable<AdivinhaInteiro> BuscaHistoricoGeral()
        {
            var retornoGeral = _services.BuscaHistoricoGeral().ToList();
            return retornoGeral;
        }

        public void LimpaHistorico()
        {
            _services.LimpaHistorico();
        }

        public string ConfirmarJogada(int numeroJogador, string dificuldade, int palpitejogador)
        {
            try
            {
                var retornoConfirmacao = _services.ConfirmarJogada(numeroJogador, palpitejogador);
                return retornoConfirmacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}


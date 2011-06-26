using System;
using System.Web.Mvc;
using Cielo.Messages;

namespace Cielo.Exemplo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cielo = new CieloClient();

            var pedido = new DadosPedido("1254", 1.02M, "produto");

            var resposta = cielo.CriarTransacao(pedido, Bandeira.Visa, new Uri("http://localhost:57660/Home/Retorno/1254"));

            if (!resposta.IsErro())
            {
                Session["tid"] = resposta.Transacao.tid;

                return Redirect(resposta.Transacao.urlautenticacao);
            }
            else
                return View();
        }

        public ActionResult Retorno(string id)
        {
            var cielo = new CieloClient();

            var resposta = cielo.ConsultarTransacao(Session["tid"].ToString());

            if (!resposta.IsErro())
            {
                resposta = cielo.CancelarTransacao(resposta.Transacao.tid);
            }

            return View();
        }

    }
}

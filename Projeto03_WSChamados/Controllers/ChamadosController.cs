using Projeto03_WSChamados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto03_WSChamados.Controllers
{
    public class ChamadosController : ApiController
    {

        static readonly ChamadosRepository repo =
            new ChamadosRepository();

        //HTTP GET - LISTA TODOS OS CHAMADOS
        public IEnumerable<Chamado> GetChamados()
        {
            return repo.BuscarChamados();
        }

        [Route("chamados/{id}")]
        public IEnumerable<Chamado> GetChamadosId(int? id)
        {
            return repo.BuscarChamados(id);
        }
        //HTTP POST - INCLUSÃO DE UM CHAMADO
        public HttpResponseMessage PostChamados(Chamado chamado)
        {

            bool resposta = repo.GravarChamado(chamado);

            if (resposta)
            {
                var response = Request.CreateResponse<Chamado>(
                    HttpStatusCode.Created, chamado);

                string uri = Url.Link("DefaultApi", new { id = chamado.ChamadoID });

                return response;
            }
            else
            {
                var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Erro no Servidor"),
                    ReasonPhrase = "Não foi possivel gravar seu chamado! Por favor, tente novamente ou entre em contato com o administrador!"
                };

                throw new HttpResponseException(erro);
            }
        }



    }
}

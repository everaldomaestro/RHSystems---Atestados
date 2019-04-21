using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Services.WebApi.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atestados.Services.WebApi.Controllers
{
    public class UnidadeApiController : ApiController, IUnidadeApiController
    {
        private readonly IUnidadeAppServices _unidadeAppServices;

        public UnidadeApiController(IUnidadeAppServices unidadeAppServices)
        {
            _unidadeAppServices = unidadeAppServices;
        }

        [Route("unidades")]
        public HttpResponseMessage Get()
        {
            var result = _unidadeAppServices.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("unidades/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _unidadeAppServices.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("unidades")]
        public HttpResponseMessage Post(Unidade unidade)
        {
            if (unidade == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _unidadeAppServices.Add(unidade);
                return Request.CreateResponse(HttpStatusCode.OK, unidade);
            }
        }

        [HttpPut]
        [Route("unidades")]
        public HttpResponseMessage Put(Unidade unidade)
        {
            if (unidade == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _unidadeAppServices.Update(unidade);
                return Request.CreateResponse(HttpStatusCode.OK, unidade);
            }
        }

        [HttpDelete]
        [Route("unidades")]
        public HttpResponseMessage Delete(Unidade unidade)
        {
            if (unidade.UnidadeId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _unidadeAppServices.Delete(unidade);
                return Request.CreateResponse(HttpStatusCode.OK, "Unidade excluída");
            }
        }
    }
}

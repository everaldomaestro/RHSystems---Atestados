using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Services.WebApi.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atestados.Services.WebApi.Controllers
{
    public class AtestadosAuxApiController : ApiController, IAtestadosAuxApiController
    {
        private readonly IAtestadosAuxAppServices _atestadosAuxAppServices;

        public AtestadosAuxApiController(IAtestadosAuxAppServices atestadosAuxAppServices)
        {
            _atestadosAuxAppServices = atestadosAuxAppServices;
        }

        [Route("atestadosAux")]
        public HttpResponseMessage Get()
        {
            var result = _atestadosAuxAppServices.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("atestadosAux/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _atestadosAuxAppServices.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("atestadosAux")]
        public HttpResponseMessage Post(AtestadosAux atestadosAux)
        {
            if (atestadosAux == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _atestadosAuxAppServices.Add(atestadosAux);
                return Request.CreateResponse(HttpStatusCode.OK, atestadosAux);
            }
        }

        [HttpPut]
        [Route("atestadosAux")]
        public HttpResponseMessage Put(AtestadosAux atestadosAux)
        {
            if (atestadosAux == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _atestadosAuxAppServices.Update(atestadosAux);
                return Request.CreateResponse(HttpStatusCode.OK, atestadosAux);
            }
        }

        [HttpDelete]
        [Route("atestadosAux")]
        public HttpResponseMessage Delete(AtestadosAux atestadosAux)
        {
            if (atestadosAux.AtestadoAuxId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _atestadosAuxAppServices.Delete(atestadosAux);
                return Request.CreateResponse(HttpStatusCode.OK, "AtestadosAux excluído");
            }
        }
    }
}

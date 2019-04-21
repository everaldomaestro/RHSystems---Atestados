using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Services.WebApi.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atestados.Services.WebApi.Controllers
{
    public class AtestadoApiController : ApiController, IAtestadoApiController
    {
        private readonly IAtestadoAppServices _atestadoAppServices;

        public AtestadoApiController(IAtestadoAppServices atestadoAppServices)
        {
            _atestadoAppServices = atestadoAppServices;
        }

        [Route("atestados")]
        public HttpResponseMessage Get()
        {
            var result = _atestadoAppServices.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("atestados/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _atestadoAppServices.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("atestados")]
        public HttpResponseMessage Post(Atestado atestado)
        {
            if (atestado == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _atestadoAppServices.Add(atestado);
                return Request.CreateResponse(HttpStatusCode.OK, atestado);
            }
        }

        [HttpPut]
        [Route("atestados")]
        public HttpResponseMessage Put(Atestado atestado)
        {
            if (atestado == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _atestadoAppServices.Update(atestado);
                return Request.CreateResponse(HttpStatusCode.OK, atestado);
            }
        }

        [HttpDelete]
        [Route("atestados")]
        public HttpResponseMessage Delete(Atestado atestado)
        {
            if (atestado.AtestadoId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _atestadoAppServices.Delete(atestado);
                return Request.CreateResponse(HttpStatusCode.OK, "Atestado excluído");
            }
        }
    }
}

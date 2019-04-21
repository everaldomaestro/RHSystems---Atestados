using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Services.WebApi.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atestados.Services.WebApi.Controllers
{
    public class ColaboradorApiController : ApiController, IColaboradorApiController
    {
        private readonly IColaboradorAppServices _colaboradorAppServices;

        public ColaboradorApiController(IColaboradorAppServices colaboradorAppServices)
        {
            _colaboradorAppServices = colaboradorAppServices;
        }

        [Route("colaboradores")]
        public HttpResponseMessage Get()
        {
            var result = _colaboradorAppServices.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("colaboradores/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _colaboradorAppServices.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("colaboradores")]
        public HttpResponseMessage Post(Colaborador colaborador)
        {
            if (colaborador == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _colaboradorAppServices.Add(colaborador);
                return Request.CreateResponse(HttpStatusCode.OK, colaborador);
            }
        }

        [HttpPut]
        [Route("colaboradores")]
        public HttpResponseMessage Put(Colaborador colaborador)
        {
            if (colaborador == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _colaboradorAppServices.Update(colaborador);
                return Request.CreateResponse(HttpStatusCode.OK, colaborador);
            }
        }

        [HttpDelete]
        [Route("colaboradores")]
        public HttpResponseMessage Delete(Colaborador colaborador)
        {
            if (colaborador.ColaboradorId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _colaboradorAppServices.Delete(colaborador);
                return Request.CreateResponse(HttpStatusCode.OK, "Colaborador excluído");
            }
        }
    }
}

using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Services.WebApi.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atestados.Services.WebApi.Controllers
{
    public class OperadorApiController : ApiController, IOperadorApiController
    {
        private readonly IOperadorAppServices _operadorAppServices;

        public OperadorApiController(IOperadorAppServices operadorAppServices)
        {
            _operadorAppServices = operadorAppServices;
        }

        [Route("operadores")]
        public HttpResponseMessage Get()
        {
            var result = _operadorAppServices.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("operadores/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _operadorAppServices.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("operadores")]
        public HttpResponseMessage Post(Operador operador)
        {
            if (operador == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _operadorAppServices.Add(operador);
                return Request.CreateResponse(HttpStatusCode.OK, operador);
            }
        }

        [HttpPut]
        [Route("operadores")]
        public HttpResponseMessage Put(Operador operador)
        {
            if (operador == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _operadorAppServices.Update(operador);
                return Request.CreateResponse(HttpStatusCode.OK, operador);
            }
        }

        [HttpDelete]
        [Route("operadores")]
        public HttpResponseMessage Delete(Operador operador)
        {
            if (operador.OperadorId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _operadorAppServices.Delete(operador);
                return Request.CreateResponse(HttpStatusCode.OK, "Operador excluído");
            }
        }
    }
}

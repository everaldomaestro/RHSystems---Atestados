using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Services.WebApi.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atestados.Services.WebApi.Controllers
{
    public class SetorApiController : ApiController, ISetorApiController
    {
        private readonly ISetorAppServices _setorAppServices;

        public SetorApiController(ISetorAppServices setorAppServices)
        {
            _setorAppServices = setorAppServices;
        }

        [Route("setores")]
        public HttpResponseMessage Get()
        {
            var result = _setorAppServices.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("setores/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _setorAppServices.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("setores")]
        public HttpResponseMessage Post(Setor setor)
        {
            if (setor == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _setorAppServices.Add(setor);
                return Request.CreateResponse(HttpStatusCode.OK, setor);
            }
        }

        [HttpPut]
        [Route("setores")]
        public HttpResponseMessage Put(Setor setor)
        {
            if (setor == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _setorAppServices.Update(setor);
                return Request.CreateResponse(HttpStatusCode.OK, setor);
            }
        }

        [HttpDelete]
        [Route("setores")]
        public HttpResponseMessage Delete(Setor setor)
        {
            if (setor.SetorId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _setorAppServices.Delete(setor);
                return Request.CreateResponse(HttpStatusCode.OK, "Setor excluído");
            }
        }
    }
}

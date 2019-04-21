using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Services.WebApi.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atestados.Services.WebApi.Controllers
{
    public class CidApiController : ApiController, ICidApiController
    {
        private readonly ICidAppServices _cidAppServices;

        public CidApiController(ICidAppServices cidAppServices)
        {
            _cidAppServices = cidAppServices;
        }

        [Route("cids")]
        public HttpResponseMessage Get()
        {
            var result = _cidAppServices.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("cids/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _cidAppServices.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("cids")]
        public HttpResponseMessage Post(Cid cid)
        {
            if (cid == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _cidAppServices.Add(cid);
                return Request.CreateResponse(HttpStatusCode.OK, cid);
            }
        }

        [HttpPut]
        [Route("cids")]
        public HttpResponseMessage Put(Cid cid)
        {
            if (cid == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _cidAppServices.Update(cid);
                return Request.CreateResponse(HttpStatusCode.OK, cid);
            }
        }

        [HttpDelete]
        [Route("cids")]
        public HttpResponseMessage Delete(Cid cid)
        {
            if (cid.CidId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _cidAppServices.Delete(cid);
                return Request.CreateResponse(HttpStatusCode.OK, "Cid excluído");
            }
        }
    }
}

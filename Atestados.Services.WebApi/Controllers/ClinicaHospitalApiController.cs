using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Services.WebApi.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atestados.Services.WebApi.Controllers
{
    public class ClinicaHospitalApiController : ApiController, IClinicaHospitalApiController
    {
        private readonly IClinicaHospitalAppServices _clinicaHospitalAppServices;

        public ClinicaHospitalApiController(IClinicaHospitalAppServices clinicaHospitalAppServices)
        {
            _clinicaHospitalAppServices = clinicaHospitalAppServices;
        }

        [Route("clinicasHospitais")]
        public HttpResponseMessage Get()
        {
            var result = _clinicaHospitalAppServices.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("clinicasHospitais/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _clinicaHospitalAppServices.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("clinicasHospitais")]
        public HttpResponseMessage Post(ClinicaHospital clinicaHospital)
        {
            if (clinicaHospital == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _clinicaHospitalAppServices.Add(clinicaHospital);
                return Request.CreateResponse(HttpStatusCode.OK, clinicaHospital);
            }
        }

        [HttpPut]
        [Route("clinicasHospitais")]
        public HttpResponseMessage Put(ClinicaHospital clinicaHospital)
        {
            if (clinicaHospital == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _clinicaHospitalAppServices.Update(clinicaHospital);
                return Request.CreateResponse(HttpStatusCode.OK, clinicaHospital);
            }
        }

        [HttpDelete]
        [Route("clinicasHospitais")]
        public HttpResponseMessage Delete(ClinicaHospital clinicaHospital)
        {
            if (clinicaHospital.ClinicaHospitalId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _clinicaHospitalAppServices.Delete(clinicaHospital);
                return Request.CreateResponse(HttpStatusCode.OK, "Clinica\\Hospital excluído");
            }
        }
    }
}

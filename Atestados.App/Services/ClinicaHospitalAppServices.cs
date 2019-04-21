using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.App.Services
{
    public class ClinicaHospitalAppServices : AppServiceBase<ClinicaHospital>, IClinicaHospitalAppServices
    {
        private readonly IClinicaHospitalServices _clinicaHospitalServices;

        public ClinicaHospitalAppServices(IClinicaHospitalServices clinicaHospitalServices)
            : base(clinicaHospitalServices)
        {
            _clinicaHospitalServices = clinicaHospitalServices;
        }
    }
}

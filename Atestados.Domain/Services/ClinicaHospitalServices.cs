using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Repositories;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.Domain.Services
{
    public class ClinicaHospitalServices : ServiceBase<ClinicaHospital>, IClinicaHospitalServices
    {
        private readonly IClinicaHospitalRepository _clinicaHospitalRepository;

        public ClinicaHospitalServices(IClinicaHospitalRepository clinicaHospitalRepository)
            : base(clinicaHospitalRepository)
        {
            _clinicaHospitalRepository = clinicaHospitalRepository;
        }
    }
}

using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.App.Services
{
    public class ColaboradorAppServices : AppServiceBase<Colaborador>, IColaboradorAppServices
    {
        private readonly IColaboradorServices _colaboradorServices;

        public ColaboradorAppServices(IColaboradorServices colaboradorServices)
            : base(colaboradorServices)
        {
            _colaboradorServices = colaboradorServices;
        }

        public Colaborador GetByCPF(string cpf)
        {
            return _colaboradorServices.GetByCPF(cpf);
        }
    }
}

using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.App.Services
{
    public class SetorAppServices : AppServiceBase<Setor>, ISetorAppServices
    {
        private readonly ISetorServices _setorServices;

        public SetorAppServices(ISetorServices setorServices)
            : base(setorServices)
        {
            _setorServices = setorServices;
        }
    }
}

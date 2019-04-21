using Atestados.App.Interfaces;
using Atestados.Domain.Entities;
using Atestados.Domain.Interfaces.Services;

namespace Atestados.App.Services
{
    public class CidAppServices : AppServiceBase<Cid>, ICidAppServices
    {
        private readonly ICidServices _cidServices;

        public CidAppServices(ICidServices cidServices)
            : base(cidServices)
        {
            _cidServices = cidServices;
        }
    }
}

using Atestados.Domain.Entities;
using Atestados.Presentation.MVC.ViewModels;
using AutoMapper;

namespace Atestados.Presentation.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ColaboradorViewModel, Colaborador>();
            CreateMap<SetorViewModel, Setor>();
            CreateMap<UnidadeViewModel, Unidade>();
            CreateMap<ClinicaHospitalViewModel, ClinicaHospital>();
            CreateMap<CidViewModel, Cid>();
            CreateMap<AtestadoViewModel, Atestado>();
            CreateMap<AtestadosAuxViewModel, AtestadosAux>();
            CreateMap<OperadorViewModel, Operador>();
        }
    }
}
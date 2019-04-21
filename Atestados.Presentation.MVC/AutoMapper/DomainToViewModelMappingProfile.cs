using Atestados.Domain.Entities;
using Atestados.Presentation.MVC.ViewModels;
using AutoMapper;

namespace Atestados.Presentation.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Colaborador, ColaboradorViewModel>();
            CreateMap<Setor, SetorViewModel>();
            CreateMap<Unidade, UnidadeViewModel>();
            CreateMap<ClinicaHospital, ClinicaHospitalViewModel>();
            CreateMap<Cid, CidViewModel>();
            CreateMap<Atestado, AtestadoViewModel>();
            CreateMap<AtestadosAux, AtestadosAuxViewModel>();
            CreateMap<Operador, OperadorViewModel>();
        }
    }
}
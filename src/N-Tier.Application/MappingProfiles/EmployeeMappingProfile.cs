using AutoMapper;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeModel, Employee>().
                ForPath(e => e.Person.Age, o => o.MapFrom(o => o.Age))
                .ForPath(e => e.Person.Name, o => o.MapFrom(o => o.Name))
                .ForPath(e => e.Person.Gender, o => o.MapFrom(o => o.Gender));
            CreateMap<UpdateEmployeeModel, Employee>();
            CreateMap<Employee, EmployeeResponseModel>();
        }
    }
}

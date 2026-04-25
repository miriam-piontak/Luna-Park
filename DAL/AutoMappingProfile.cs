using AutoMapper;
using DAL.Models;
using DTO;
namespace DAL
{
    internal class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            //casting Attraction to AttractionDTO and the opocite.
            CreateMap<Attraction, AttractionDTO>().ReverseMap();



            //casting Employee to EmployeeDTO 
            CreateMap<Employee, EmployeeDTO>()
                //full name
                .ForMember(dest => dest.FullName, source => source.MapFrom(src => src.EmployeeFirstName + " " + src.EmployeeLastName))
                //AttractionName
                .ForMember(dest => dest.AttractionName, opt => opt.MapFrom(src => src.Attraction != null ? src.Attraction.AttractionName : "לא נמצא שם"));

            //casting EmployeeDTO to Employee
            CreateMap<EmployeeDTO, Employee>()
                //first name
                .ForMember(dest => dest.EmployeeFirstName, source => source.MapFrom(src => src.FullName.Contains(" ")
                    ? src.FullName.Substring(0, src.FullName.LastIndexOf(" ")).Trim()
                    : src.FullName))
                //last name
                .ForMember(dest => dest.EmployeeLastName, source => source.MapFrom(src => src.FullName.Contains(" ")
                    ? src.FullName.Substring(0, src.FullName.LastIndexOf(" ") + 1).Trim()
                    : ""));



            //casting Ticket to TicketDTO
            CreateMap<Ticket, TicketDTO>()
                //AttractionName
                .ForMember(dest => dest.AttractionName, source => source.MapFrom(src => src.Attraction != null ? src.Attraction.AttractionName : "לא נמצא שם"))
                //SellerName
                .ForMember(dest => dest.SellerName, source => source.MapFrom(src => src.Employee != null ? src.Employee.EmployeeFirstName + " " + src.Employee.EmployeeLastName : "לא נמצא שם"));


            //casting TicketDTO to Ticket
            CreateMap<TicketDTO, Ticket>();



        }
    }
}

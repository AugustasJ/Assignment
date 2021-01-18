using AutoMapper;

namespace HomeAssignmentLibrary.API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Entities.Customer, Models.CustomerDto>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}

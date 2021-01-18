using AutoMapper;
using HomeAssignmentLibrary.API.Helpers;

namespace HomeAssignmentLibrary.API.Profiles
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<Entities.Agreement, Models.ResponseDto>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"))
                .ForMember(dest => dest.PersonalId,
                    opt => opt.MapFrom(src => src.Customer.PersonalId))
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Amount,
                    opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.BaseRateCode,
                    opt => opt.MapFrom(src => src.BaseRateCode))
                .ForMember(dest => dest.NewBaseRateCode,
                    opt => opt.MapFrom(src => src.NewBaseRateCode))
                .ForMember(dest => dest.Margin,
                    opt => opt.MapFrom(src => src.Margin))
                .ForMember(dest => dest.AgreementDuration,
                    opt => opt.MapFrom(src => src.AgreementDuration))
                .ForMember(dest => dest.InterestRateForCurrentBaseRate,
                    opt => opt.MapFrom(src => InterestCalculator.GetInterestRate(src.BaseRateCode, src.Margin)))
                .ForMember(dest => dest.InterestRateForNewBaseRate,
                    opt => opt.MapFrom(src => InterestCalculator.GetInterestRate(src.NewBaseRateCode, src.Margin)))
                .ForMember(dest => dest.InterestRateDifference,
                    opt => opt.MapFrom(src => InterestCalculator.GetDifference(src.BaseRateCode, src.NewBaseRateCode, src.Margin)));
        }
    }
}

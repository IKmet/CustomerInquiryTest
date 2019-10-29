using AutoMapper;
using CustomerInquiry.DB.Enums;
using System;

namespace CustomerInquiry
{
  public class MappingProfile : Profile
  {
    private const string DateTimeFormat = "dd/MM/yyyy HH:mm";

    public MappingProfile()
    {
      CreateMap<DB.Models.Transaction, Common.DTO.Transaction>()
        .ForMember(dest => dest.Currency,
                  opt => opt.MapFrom(src => Enum.GetName(typeof(CurrencyCode), src.Currency)))
        .ForMember(dest => dest.Status,
                  opt => opt.MapFrom(src => Enum.GetName(typeof(Status), src.Status)))
        .ForMember(dest => dest.DateTime,
                  opt => opt.MapFrom(src => src.DateTime.ToString(DateTimeFormat)));
    }
  }
}
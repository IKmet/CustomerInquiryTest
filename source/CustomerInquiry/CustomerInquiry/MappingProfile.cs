using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry {
  public class MappingProfile : Profile {
    public MappingProfile() {
      CreateMap<DB.Models.Customer, Common.DTO.Customer>();
      CreateMap<Common.DTO.Customer, DB.Models.Customer>();
      CreateMap<DB.Models.Transaction, Common.DTO.Transaction>();
      CreateMap<Common.DTO.Transaction, DB.Models.Transaction>();
    }
  }
}
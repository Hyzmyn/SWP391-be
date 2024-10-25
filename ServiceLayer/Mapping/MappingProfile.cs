using AutoMapper;
using ModelLayer.Entities;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            //CreateMap<Certification, CertificationResponse>()
            //    .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.User != null ? src.User : null))
            //    .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet != null ? src.Pet.Name : null));

            //CreateMap<Certification, CertificationResponseDetail>()
            //    .ForMember(dest => dest.ShelterStaff, opt => opt.MapFrom(src => src.User))
            //    .ForMember(dest => dest.Pet, opt => opt.MapFrom(src => src.Pet));

            //CreateMap<User, UsersResponseModel>();
            //CreateMap<Pet, PetDetailResponse>();

            //// DTO to Entity
            //CreateMap<CertificationRequest, Certification>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore())
            //    .ForMember(dest => dest.User, opt => opt.Ignore())
            //    .ForMember(dest => dest.Pet, opt => opt.Ignore());
        }
    }
}

using AutoMapper;
using EditableCV_backend.DataTransferObjects;
using EditableCV_backend.DataTransferObjects.CommonInfoDto;
using EditableCV_backend.DataTransferObjects.EducationalInstitutionDto;
using EditableCV_backend.DataTransferObjects.WorkPlaceDto;
using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace EditableCV_backend.Profiles
{
  public class ResumeProfile : Profile
  {
    public ResumeProfile()
    {
      CreateMap<WorkPlace, WorkPlaceReadDto>();
      CreateMap<WorkPlaceCreateDto, WorkPlace>();
      CreateMap<WorkPlaceUpdateDto, WorkPlace>();
      CreateMap<WorkPlace, WorkPlaceUpdateDto>();

      CreateMap<CommonInfo, CommonInfoReadDto>();
      CreateMap<CommonInfoCreateDto, CommonInfo>();
      CreateMap<CommonInfo, CommonInfoReadLandingDto>()
        .ForMember(
          dto => dto.Age,
          info => info.MapFrom(commonInfo => GetAgeByDateOfBirth(commonInfo.DateOfBirth))
        );

      CreateMap<EducationalInstitution, InstitutionReadDto>();
      CreateMap<InstitutionCreateDto, EducationalInstitution>();
      CreateMap<InstitutionUpdateDto, EducationalInstitution>();
      CreateMap<EducationalInstitution, InstitutionUpdateDto>();
    }

    private int GetAgeByDateOfBirth(DateTime dateOfBirth)
    {
      var today = DateTime.Today;
      var age = today.Year - dateOfBirth.Year;
      if (dateOfBirth.Date > today.AddYears(-age)) age--;
      return age;
    }
  }
}

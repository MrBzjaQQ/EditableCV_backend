﻿using AutoMapper;
using EditableCV_backend.Data.ContactInfoData;
using EditableCV_backend.Data.ContactInfoDto;
using EditableCV_backend.DataTransferObjects;
using EditableCV_backend.DataTransferObjects.CommonInfoDto;
using EditableCV_backend.DataTransferObjects.EducationalInstitutionDto;
using EditableCV_backend.DataTransferObjects.LandingDto;
using EditableCV_backend.DataTransferObjects.SkillDto;
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
      CreateWorkPlaceMapping();
      CreateCommonInfoMapping();
      CreateEducationMapping();
      CreateSkillMapping();
      CreateContactInfoMapping();
      CreateLandingDataMapping();
    }

    private void CreateWorkPlaceMapping()
    {
      CreateMap<WorkPlace, WorkPlaceReadDto>();
      CreateMap<WorkPlaceCreateDto, WorkPlace>();
      CreateMap<WorkPlaceUpdateDto, WorkPlace>();
      CreateMap<WorkPlace, WorkPlaceUpdateDto>();
    }

    private void CreateCommonInfoMapping()
    {
      CreateMap<CommonInfo, CommonInfoReadDto>();
      CreateMap<CommonInfoCreateDto, CommonInfo>();
      CreateMap<CommonInfo, CommonInfoReadLandingDto>()
        .ForMember(
          dto => dto.Age,
          info => info.MapFrom(commonInfo => GetAgeByDateOfBirth(commonInfo.DateOfBirth))
        );
    }

    private void CreateEducationMapping()
    {
      CreateMap<EducationalInstitution, InstitutionReadDto>();
      CreateMap<InstitutionCreateDto, EducationalInstitution>();
      CreateMap<InstitutionUpdateDto, EducationalInstitution>();
      CreateMap<EducationalInstitution, InstitutionUpdateDto>();
    }

    private void CreateSkillMapping()
    {
      CreateMap<Skill, SkillReadDto>();
      CreateMap<SkillCreateDto, Skill>();
      CreateMap<SkillUpdateDto, Skill>();
      CreateMap<Skill, SkillUpdateDto>();
    }

    private void CreateContactInfoMapping()
    {
      CreateMap<ContactInfo, ContactInfoReadDto>();
      CreateMap<ContactInfoUpdateDto, ContactInfo>();
    }

    private void CreateLandingDataMapping()
    {
      CreateMap<LandingDataModel, LandingReadDto>();
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
